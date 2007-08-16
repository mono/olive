//
// ServiceModelInternalConverter.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;
using System.Text;
using Mono.CodeGeneration;

namespace System.ServiceModel.Description
{
	internal class MessageDescriptionMapping
	{
		public Type ProxyType;
		public List<FieldInfo> Fields = new List<FieldInfo> ();
	}

	internal static class ServiceModelInternalConverter
	{
		public static TypedMessageMapping MessageContractToDataContractMap (Type src, string defaultNS)
		{
			return ToDataContractType (src, MessageContractToMessageBody (src), defaultNS);
		}

		public static MessageDescriptionMapping MessageBodyToDataContractType (MessageBodyDescription desc)
		{
			MessageDescriptionMapping map = new MessageDescriptionMapping ();
			List<string> fields = new List<string> ();

			string modname = "dummy";

			// type
			CodeClass c = new CodeModule (modname).CreateClass (
				"__mdproxy_" + desc.WrapperName, typeof (object));
			c.CreateCustomAttribute (typeof (DataContractAttribute), Type.EmptyTypes, new object [0], new string [] {"Name", "Namespace"}, new object [] {desc.WrapperName, desc.WrapperNamespace});

			// parameters
			List<MessagePartDescription> parts =
				new List<MessagePartDescription> ();
			parts.AddRange (desc.Parts);
			if (desc.ReturnValue != null)
				parts.Add (desc.ReturnValue);
			foreach (MessagePartDescription part in parts) {
				Type type = part.Type;
				if (type == typeof (void))
					type = typeof (object); // mostly for return value of void.
				c.DefineField (part.Name, type,
					FieldAttributes.Public, null,
					CodeCustomAttribute.Create (typeof (DataMemberAttribute), Type.EmptyTypes, new object [0], new string [] {"Name"}, new object [] {part.Name}));
				fields.Add (part.Name);
			}

			//Type zzz = c.CreateType ();
			//((System.Reflection.Emit.AssemblyBuilder) zzz.Assembly).Save (modname + ".dll");
			//map.ProxyType = zzz;
			map.ProxyType = c.CreateType ();

			foreach (string pname in fields)
				map.Fields.Add (map.ProxyType.GetField (pname));
			return map;
		}

		static TypedMessageMapping ToDataContractType (Type src, MessageBodyDescription desc, string defaultNS)
		{
			TypedMessageMapping map = new TypedMessageMapping ();
			map.IsWrapped = desc.WrapperName != null;
			List<string> props = new List<string> ();

			string modname = "dummy";

			// type
			CodeClass c = new CodeModule (modname).CreateClass (
				"__mcproxy_" + src.Name, typeof (object));
			c.CreateCustomAttribute (typeof (DataContractAttribute), Type.EmptyTypes, new object [0], new string [] {"Name", "Namespace"}, new object [] {src.Name, defaultNS});

			// source
			CodeFieldReference fref = c.DefineField ("__source", src);

			// .ctor()
			CodeMethod ctor = c.CreateConstructor (MethodAttributes.Public, src);
			ctor.CodeBuilder.Assign (fref, ctor.GetArg (0));

			// properties
			foreach (MessagePartDescription part in desc.Parts) {
				CodeProperty prop = c.CreateProperty (part.MemberInfo.Name, GetMemberType (part.MemberInfo), MethodAttributes.Public);
				CodeBuilder b = prop.CodeBuilderGet;
				PropertyInfo srcProp = part.MemberInfo as PropertyInfo;
				if (srcProp != null)
					b.Return (new CodePropertyReference (
						fref, srcProp));
				else
					b.Return (new CodeFieldReference (
						fref, (FieldInfo) part.MemberInfo));
				prop.CreateCustomAttribute (typeof (DataMemberAttribute), Type.EmptyTypes, new object [0], new string [] {"Name"}, new object [] {part.MemberInfo.Name});
				props.Add (part.MemberInfo.Name);
			}

			//Type zzz = c.CreateType ();
			//((System.Reflection.Emit.AssemblyBuilder) zzz.Assembly).Save (modname + ".dll");
			//map.ProxyType = zzz;
			map.ProxyType = c.CreateType ();

			foreach (string pname in props)
				map.Properties.Add (map.ProxyType.GetProperty (pname));

			return map;
		}

		static Type GetMemberType (MemberInfo mi)
		{
			if (mi is FieldInfo)
				return ((FieldInfo) mi).FieldType;
			if (mi is PropertyInfo)
				return ((PropertyInfo) mi).PropertyType;
			throw new Exception ("INTERNAL ERROR: " + mi.GetType ());
		}

		public static Type ToXmlSerializableType (Type src, string defaultNS)
		{
			MessageBodyDescription desc =
				MessageContractToMessageBody (src);

			throw new NotImplementedException ();
		}

		static MessageBodyDescription MessageContractToMessageBody (
			Type src)
		{
			MessageContractAttribute mca =
				ContractDescriptionGenerator.GetMessageContractAttribute (src);

			if (mca == null)
				throw new ArgumentException (String.Format ("Type {0} and its ancestor types do not have MessageContract attribute.", src));

			MessageBodyDescription mb = new MessageBodyDescription ();
			if (mca.IsWrapped) {
				mb.WrapperName = mca.WrapperName ?? src.Name;
				mb.WrapperNamespace = mca.WrapperNamespace ?? TypedMessageConverter.TempUri;
			}

			ContractDescriptionGenerator.FillMessageBodyDescriptionByContract (src, mb);

			return mb;
		}
	}
}
