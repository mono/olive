//
// ManagedXamlLoader.cs
//
// Authors:
//   Rolf Bjarne Kvinge (RKvinge@novell.com)
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
using Mono;

namespace Mono.Xaml
{
	public delegate IntPtr LoadObjectCallback (string asm_name, string asm_path, string ns, string type_name);
	public delegate void SetAttributeCallback (IntPtr target, string name, string value);
	public delegate bool HookupEventCallback (IntPtr target, string name, string value);
	public delegate void InsertMappingCallback (string key, string value);
	public delegate string GetMappingCallback (string key);
	
	public struct XamlLoaderCallbacks {
		public LoadObjectCallback load_managed_object;
		public SetAttributeCallback set_custom_attribute;
		public HookupEventCallback hookup_event;
		public GetMappingCallback get_mapping;
		public InsertMappingCallback insert_mapping;
	}

	public enum AssemblyLoadResult
	{
		Success = -1,
		MissingAssembly = 1,
		LoadFailure = 2
	}
	
	public abstract class XamlLoader : MarshalByRefObject
	{
		public abstract void Setup (IntPtr native_loader, IntPtr plugin, IntPtr surface, string filename, string contents);
		
	}
}
