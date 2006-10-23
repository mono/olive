using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Mono.ServiceContractTool
{
	public class Driver
	{
		public static void Main (string [] args)
		{
			new Driver ().Run (args);
		}

		CommandLineOptions co = new CommandLineOptions ();
		ServiceContractGenerator generator;
		CodeDomProvider code_provider;

		void Run (string [] args)
		{
			co.ProcessArgs (args);
			if (co.RemainingArguments.Length == 0)
				co.DoHelp ();
			if (!co.NoLogo)
				co.ShowBanner ();

			CodeCompileUnit ccu = new CodeCompileUnit ();
			CodeNamespace cns = new CodeNamespace (co.Namespace);
			ccu.Namespaces.Add (cns);

			generator = new ServiceContractGenerator (ccu);
			generator.Options = GetGenerationOption ();

			code_provider = GetCodeProvider ();

			// For now only assemblyPath is supported.
			foreach (string arg in co.RemainingArguments) {
				FileInfo fi = new FileInfo (arg);
				if (!fi.Exists)
					throw new ArgumentException (String.Format ("File {0} not found.", fi.Name));
				switch (fi.Extension) {
				case ".exe":
				case ".dll":
					GenerateContractType (fi.FullName);
					break;
				default:
					throw new NotSupportedException ("Not supported file extension: " + fi.Extension);
				}
			}

			if (cns.Types.Count == 0) {
				Console.Error.WriteLine ("Argument assemblies have no types.");
				Environment.Exit (1);
			}

			using (TextWriter w = File.CreateText (GetOutputFilename ())) {
				code_provider.GenerateCodeFromCompileUnit (ccu, w, null);
			}
		}

		CodeDomProvider GetCodeProvider ()
		{
			switch (co.Language) {
			case "csharp":
			case "cs":
				return new Microsoft.CSharp.CSharpCodeProvider ();
			case "vb":
				return new Microsoft.VisualBasic.VBCodeProvider ();
			default:
				throw new NotSupportedException ();
			}
		}

		void GenerateContractType (string file)
		{
			Assembly ass = Assembly.LoadFile (file);
			foreach (Module m in ass.GetModules ())
				foreach (Type t in m.GetTypes ())
					ProcessType (t);
		}

		void ProcessType (Type type)
		{
			object [] a = type.GetCustomAttributes (
				typeof (ServiceContractAttribute), true);
			if (a.Length > 0)
				generator.GenerateServiceContractType (
					ContractDescription.GetContract (type));
		}

		ServiceContractGenerationOptions GetGenerationOption ()
		{
			ServiceContractGenerationOptions go =
				ServiceContractGenerationOptions.ClientClass;
			if (co.GenerateAsync)
				go |= ServiceContractGenerationOptions.AsynchronousMethods;
			if (co.ChannelInterface)
				go |= ServiceContractGenerationOptions.ChannelInterface;
			if (co.GenerateTypesAsInternal)
				go |= ServiceContractGenerationOptions.InternalTypes;
			if (co.GenerateProxy)
				go |= ServiceContractGenerationOptions.ClientClass;
			if (co.GenerateTypedMessages)
				go |= ServiceContractGenerationOptions.TypedMessages;
			return go;
		}

		string GetOutputFilename ()
		{
			if (co.OutputFilename != null)
				return co.OutputFilename;
			return "output." + code_provider.FileExtension;
		}
	}
}
