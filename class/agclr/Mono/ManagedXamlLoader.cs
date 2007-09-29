 //
// ManagedXamlLoader.cs
//
// Authors:
//   Rolf Bjarne Kvinge (RKvinge@novell.com)
//   Miguel de Icaza (miguel@ximian.com)
//
// Copyright 2007 Novell, Inc.
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

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Mono;

namespace Mono.Xaml
{
	internal class ManagedXamlLoader : XamlLoader	{
		IntPtr plugin;
//		IntPtr surface;
		IntPtr native_loader;
//		string filename;
//		string contents;
		static Dictionary<string, string> mappings = new Dictionary <string, string> ();
		XamlLoaderCallbacks callbacks;

#if WITH_DLR
		DLRHost dlr_host;
#endif
				
		public IntPtr PluginHandle {
			get {
				return plugin;
			}
		}
		
		public IntPtr NativeLoader {
			get {
				return native_loader;
			}
		}
		
		public ManagedXamlLoader ()
		{
		}
		
		public void CreateNativeLoader (string filename, string contents)
		{
			native_loader = NativeMethods.xaml_loader_new (filename, contents, IntPtr.Zero);
			
			if (native_loader == IntPtr.Zero)
				throw new Exception ("Unable to create native loader.");
			
			Setup (native_loader, IntPtr.Zero, IntPtr.Zero, filename, contents);
		}
		
		public void FreeNativeLoader ()
		{
			NativeMethods.xaml_loader_free (native_loader);
			native_loader = IntPtr.Zero;
		}
		
		public override void Setup (IntPtr native_loader, IntPtr plugin, IntPtr surface, string filename, string contents)
		{
			this.native_loader = native_loader;
			this.plugin = plugin;
//			this.surface = surface;
//			this.filename = filename;
//			this.contents = contents;

			callbacks.load_managed_object = new LoadObjectCallback (load_object);
			callbacks.set_custom_attribute = new SetAttributeCallback (set_custom_attribute);
			callbacks.hookup_event = new HookupEventCallback (hookup_event);
			callbacks.insert_mapping = new InsertMappingCallback (insert_mapping);
			callbacks.get_mapping = new GetMappingCallback (get_mapping);
			callbacks.load_code = new LoadCodeCallback (load_code);
			callbacks.set_name_attribute = new SetNameAttributeCallback (set_name_attribute);

			NativeMethods.xaml_loader_set_callbacks (native_loader, callbacks);
			
			if (plugin != IntPtr.Zero) {
				AppDomain.CurrentDomain.SetData ("PluginInstance", plugin);
				System.Windows.Interop.PluginHost.SetPluginHandle (plugin);
			}
			
		}

		private string get_mapping (string key)
		{
			try {
				return GetMapping (key);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::GetMapping ({0}) failed: {1}.", key, ex.Message);
				return null;
			}
		}
		
		public string GetMapping (string key)
		{
			if (!mappings.ContainsKey (key))
				return null;
			return mappings [key];
		}
		
		private void insert_mapping (string key, string name)
		{
			try {
				InsertMapping (key, name);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::InsertMapping ({0}, {1}) failed: {2}.", key, name, ex.Message);
			}
		}
		
		public void InsertMapping (string key, string name)
		{
			//Console.WriteLine ("ManagedXamlLoader::InsertMapping ({0}, {1}).", key, name);
			if (mappings.ContainsKey (key)){
				Console.Error.WriteLine ("ManagedXamlLoader::InsertMapping ({0}, {1}): Inserting a duplicate key? (current value: {2}).", key, name, mappings [key]);
				return;
			}
			
			mappings [key] = name;
		}
		
		public void RequestFile (string asm_path)
		{
			//Console.WriteLine ("ManagedXamlLoader::RequestFile ({0}).", asm_path);
			NativeMethods.xaml_loader_add_missing (native_loader, asm_path);
		}
	
		//
		// Tries to load the assembly.
		// Requests any referenced assemblies if necessary.
		//
		public AssemblyLoadResult LoadAssembly (string asm_path, string asm_name, out Assembly clientlib)
		{
			//Console.WriteLine ("ManagedXamlLoader::LoadAssembly (asm_path={0} asm_name={1})", asm_path, asm_name);
			
			clientlib = null;
			
			try {
				clientlib = Moonlight.LoadFile (asm_path);
			} catch (System.IO.FileNotFoundException) {
				//Console.WriteLine ("ManagedXamlLoader::LoadAssembly (asm_path={0} asm_name={1}): client library not found.", asm_path, asm_name);
				RequestFile (asm_path);
				return AssemblyLoadResult.MissingAssembly;
			}

			if (clientlib == null) {
				Console.WriteLine ("ManagedXamlLoader::LoadAssembly (asm_path={0} asm_name={1}): could not load client library: {2}", asm_path, asm_name, asm_path);
				return AssemblyLoadResult.LoadFailure;
			}

			//
			// If this assembly depends on other assemblies, we need to request them
			//
			bool missing_any = false;
			string dirname = ""; 
			int p = asm_name.LastIndexOf ('/');
			if (p != -1)
				dirname = asm_name.Substring (0, p + 1);
			
			foreach (AssemblyName an in Helper.GetReferencedAssemblies (clientlib)){

				if (an.Name == "agclr" || an.Name == "mscorlib" ||
				    an.Name == "System.Xml.Core" || an.Name == "System" ||
				    an.Name == "Microsoft.Scripting" ||
				    an.Name == "System.SilverLight" ||
				    an.Name == "System.Core")
					continue;
				//
				// This is not the best probing mechanism.
				// I do not like depending on an.Name and adding .dll
				// to figure out if we have already the assembly downloaded
				// from a previous iteration
				//
				string req = dirname + an.Name + ".dll";
				string local = GetMapping (req);

				if (local != null){
					// Ensure we load it.
					try {
						Helper.LoadFile (local);
					} catch (Exception ex) {
						Console.Error.WriteLine ("ManagedXamlLoader::LoadAssembly ({0}, {1}): failed to load {2} (from {3}): {4}", asm_path, asm_name, local, req, ex.Message);
						return AssemblyLoadResult.LoadFailure;
					}
					continue;
				}

				try {
					Assembly.Load (an);
				} catch (Exception ex) {
					//
					// If we fail, it means that the given assembly has
					// not been downloaded, request it
					//
					Console.Error.WriteLine ("ManagedXamlLoader::LoadAssembly ({0}, {1}): requesting download of '{2}' (exception: {3}).", asm_path, asm_name, req, ex.Message);
					RequestFile (req);
				}
			}
			
			if (missing_any) {
				//Console.WriteLine ("ManagedXamlLoader::LoadAssembly ({0}, {1}): failed to load (MissingAssembly).", asm_path, asm_name);
				return AssemblyLoadResult.MissingAssembly;
			}
			
			//Console.WriteLine ("ManagedXamlLoader::LoadAssembly ({0}, {1}): successfully loaded.", asm_path, asm_name);
			
			return AssemblyLoadResult.Success;
		}
		
		//
		// Proxy so that we return IntPtr.Zero in case of any failures, instead of
		// genereting an exception and unwinding the stack.
		//
		private IntPtr load_object (string asm_name, string asm_path, string ns, string type_name)
		{
			try {
				return LoadObject (asm_name, asm_path, ns, type_name);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::LoadObject ({0}, {1}, {2}, {3}) failed: {4} ({5}).", asm_name, asm_path, ns, type_name, ex.Message, ex.GetType ().FullName);
				return IntPtr.Zero;
			}
		}
		
		private IntPtr LoadObject (string asm_name, string asm_path, string ns, string type_name)
		{
			AssemblyLoadResult load_result;
			Assembly clientlib = null;
			string name;
			
			if (asm_name == null)
				throw new ArgumentNullException ("asm_name");
			
			if (asm_path == null)
				throw new ArgumentNullException ("asm_path");
						
			if (type_name == null)
				throw new ArgumentNullException ("type_name");
			
			load_result = LoadAssembly (asm_path, asm_name, out clientlib);
			
			if (load_result != AssemblyLoadResult.Success)
				return IntPtr.Zero;

			if (clientlib == null) {
				Console.WriteLine ("ManagedXamlLoader::LoadObject ({0}, {1}, {2}, {3}): Assembly loaded, but where is it?", asm_name, asm_path, ns, type_name);
				return IntPtr.Zero;
			}
			
			if (ns == null || ns == string.Empty)
				name = type_name;
			else
				name = String.Concat (ns, ".", type_name);

			object res = clientlib.CreateInstance (name);
			DependencyObject dob = res as DependencyObject;

			if (dob == null) {
				Console.Error.WriteLine ("ManagedXamlLoader::LoadObject ({0}, {1}, {2}, {3}): unable to create object instance: '{4}'", asm_name, asm_path, ns, type_name, name);
				return IntPtr.Zero;
			}
			
			return dob.native;
		}
		
		//
		// Proxy so that we return IntPtr.Zero in case of any failures, instead of
		// genreating an exception and unwinding the stack.
		//
		private void set_custom_attribute (IntPtr target_ptr, string name, string value)
		{
			try {
				SetCustomAttribute (target_ptr, name, value);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::SetCustomAttribute ({0}, {1}, {2}) threw an exception: {3}.", target_ptr, name, value, ex.Message);
			}
		}
		
		private void SetCustomAttribute (IntPtr target_ptr, string name, string value)
		{
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr); 
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (target == null) {
				//Console.Error.WriteLine ("ManagedXamlLoader::SetCustomAttribute ({0}, {1}, {2}): unable to create target object.", target_ptr, name, value);
				return;
			}

			string error;
			Helper.SetPropertyFromString (target, name, value, out error);
			if (error != null){
				//Console.Error.WriteLine ("ManagedXamlLoader::SetCustomAttribute ({0}, {1}, {2}) unable to set property: {3}.", target_ptr, name, value, error);
				return;
			}
		}

		private bool hookup_event (IntPtr target_ptr, string name, string value)
		{
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr);
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (target == null) {
				//Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to create target object.", target_ptr, name, value);
				return false;
			}

			EventInfo src = target.GetType ().GetEvent (name);
			if (src == null) {
				//Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to find event name.", target_ptr, name, value);
				return false;
			}

#if WITH_DLR
			if (dlr_host != null) {
				try {
					dlr_host.HookupEvent (target, name, value);
				}
				catch (Exception ex) {
					Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to hookup event: {3}", target_ptr, name, value, ex);
					return false;
				}
			} else {
				RememberEvent (target, name, value);
			}
#endif

			try {
				Delegate d = Delegate.CreateDelegate (src.EventHandlerType, target, value);
				if (d == null) {
					//Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to create delegate (src={3} target={4}).", target_ptr, name, value, src.EventHandlerType, target);
					return false;
				}

				src.AddEventHandler (target, d);
				return true;
			}
			catch {
				return false;
			}
		}

		private bool load_code (string source, string type)
		{
			try {
				return LoadCode (source, type);
			}
			catch (Exception ex) {
				Console.WriteLine ("ManagedXamlLoader::LoadCode ({0}, {1}): {2}", source, type, ex);
				return false;
			}
		}

		private bool LoadCode (string source, string type)
		{
			Console.WriteLine ("ManagedXamlLoader.load_code: '" + source + "' '" + type + "'");

			if (source == null) {
				Console.WriteLine ("ManagedXamlLoader.load_code: ERROR: Source can't be null.");
				return false;
			}

			if (type == null) {
				Console.WriteLine ("ManagedXamlLoader.load_code: ERROR: Type can't be null.");
				return false;
			}

			//
			// First try the desktop case
			//
			Stream s = Moonlight.LoadResource (source);
			if (s != null) {
#if WITH_DLR
				if (dlr_host == null)
					dlr_host = new DLRHost ();
				dlr_host.LoadSource (s, type, mappings);
				SetGlobalsAndEvents ();
#else
				Console.WriteLine ("ManagedXamlLoader.load_code: Ignoring request to load code.");
#endif
				return true;
			}

			//
			// Then the browser case
			//
			string local = GetMapping (source);
			if (local != null) {
				s = new FileStream (local, FileMode.Open, FileAccess.Read);
#if WITH_DLR
				if (dlr_host == null)
				    dlr_host = new DLRHost ();
				try {
					dlr_host.LoadSource (s, type, mappings);
				} catch (MissingReferenceException ex) {
					RequestFile (ex.Reference);
					return false;
				} catch (Exception ex) {
					if (Events.IsPlugin ()) {
						Events.ReportException (ex);
						// This is not a fatal error
						return true;
					}
					else
						throw;
				}
				SetGlobalsAndEvents ();
#else
				Console.WriteLine ("ManagedXamlLoader.load_code: Ignoring request to load code.");
#endif
				return true;
			} else {
				RequestFile (source);

				return false;
			}
		}

		private void set_name_attribute (IntPtr target_ptr, string name)
		{
			try {
				SetNameAttribute (target_ptr, name);
			}
			catch (Exception ex) {
				Console.WriteLine ("ManagedXamlLoader::SetNameAttribute () threw an exception: " + ex);
			}
		}

		private void SetNameAttribute (IntPtr target_ptr, string name) {
#if WITH_DLR
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr); 
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (dlr_host != null) {
				dlr_host.SetVariable (name, target);
			} else {
				RememberName (target, name);
			}
#endif
		}

#if WITH_DLR
		private class RememberedEvent {
			public DependencyObject target;
			public string name;
			public string value;
		}

		private Dictionary<string, DependencyObject> named_objects;

		private Dictionary<RememberedEvent, RememberedEvent> events;

		//
		// When SetNameAttribute and hookup_event are called, scripts are not yet loaded.
		// So we store the info in hash tables and process them after a script has been
		// loaded
		private void RememberName (DependencyObject target, string name) {
			if (named_objects == null)
				named_objects = new Dictionary<string, DependencyObject> ();
			named_objects [name] = target;
		}

		private void RememberEvent (DependencyObject target, string name, string value) {
			if (events == null)
				events = new Dictionary<RememberedEvent, RememberedEvent> ();
			RememberedEvent ev = new RememberedEvent ();
			ev.target = target;
			ev.name = name;
			ev.value = value;
			events [ev] = ev;
		}

		private void SetGlobalsAndEvents () {
			if (named_objects != null) {
				foreach (KeyValuePair<string, DependencyObject> kvp in named_objects)
					dlr_host.SetVariable (kvp.Key, kvp.Value);
				named_objects = null;
			}
			if (events != null) {
				foreach (RememberedEvent ev in events.Keys) {
					dlr_host.HookupEvent (ev.target, ev.name, ev.value);
				}
			}
		}
#endif
	}
}
