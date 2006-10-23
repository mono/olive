//
// SvcHttpHandlerFactory.cs
//
// Author:
//	Ankit Jain  <jankit@novell.com>
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Caching;

namespace System.ServiceModel.Channels {

	internal class SvcHttpHandlerFactory : IHttpHandlerFactory
	{
		static Dictionary<string, SvcHttpHandler> handlers = new Dictionary<string, SvcHttpHandler> ();
		string privateBinPath;

		public SvcHttpHandlerFactory ()
		{
			ServiceHostingEnvironment.InAspNet = true;
		}

		public IHttpHandler GetHandler (HttpContext context, string requestType, string url, string pathTranslated)
		{
			if (handlers.ContainsKey (url))
				return handlers [url];
			
			Type type = GetTypeFromSvc (pathTranslated, url, context);
			if (type == null)
				throw new Exception (String.Format (
					"Could not find service for url : '{0}'", url));
			
			SvcHttpHandler handler = new SvcHttpHandler (type, url);
			handlers [url] = handler;

			return handler;
		}

		[MonoTODO]
		public void ReleaseHandler (IHttpHandler handler)
		{
			return;
		}

		internal static SvcHttpHandler GetHandler (string path)
		{
			return handlers [path];
		}

		Type GetTypeFromSvc (string path, string url, HttpContext context)
		{
			Type type = CachingCompiler.GetTypeFromCache (path);
			if (type != null)
				return type;
			
			ServiceHostParser parser = new ServiceHostParser (path, url, context);
			
			parser.Parse ();
			if (parser.Program == null) {
				//FIXME: Not caching, as parser.TypeName could be
				//just typename or fully qualified name
				type = GetTypeFromBin (parser.TypeName);
				/*CachingCompiler.InsertType (
					type, type.Assembly.Location, url, 
					new CacheItemRemovedCallback (RemovedCallback));*/
			} else {
				type = CachingCompiler.CompileAndGetType (
					parser, url,
					new CacheItemRemovedCallback (RemovedCallback));
			}

			return type;
		}
		
		string PrivateBinPath {
			get {
				if (privateBinPath != null)
					return privateBinPath;

				AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
				privateBinPath = setup.PrivateBinPath;
					
				if (!Path.IsPathRooted (privateBinPath)) {
					string appbase = setup.ApplicationBase;
					if (appbase.StartsWith ("file://")) {
						appbase = appbase.Substring (7);
						if (Path.DirectorySeparatorChar != '/')
							appbase = appbase.Replace ('/', Path.DirectorySeparatorChar);
					}
					privateBinPath = Path.Combine (appbase, privateBinPath);
				}

				return privateBinPath;
			}
		}

		//FIXME: Service="TypeName,TypeNamespace" not handled
		Type GetTypeFromBin (string typeName)
		{
			if (!Directory.Exists (PrivateBinPath))
				throw new HttpException (String.Format ("Type {0} not found.", typeName));

			string [] binDlls = Directory.GetFiles (PrivateBinPath, "*.dll");
			Type result = null;
			foreach (string dll in binDlls) {
				Assembly assembly = Assembly.LoadFrom (dll);
				Type type = assembly.GetType (typeName, false);
				if (type != null) {
					if (result != null) 
						throw new HttpException (String.Format ("Type {0} is not unique.", typeName));

					result = type;
				} 
			}

			if (result == null)
				throw new HttpException (String.Format ("Type {0} not found.", typeName));

			return result;
		}

		public static void RemovedCallback (string key, object value, CacheItemRemovedReason reason)
		{
			if (key.StartsWith (CachingCompiler.cacheTypePrefix)) {
				string path = key.Remove (0, CachingCompiler.cacheTypePrefix.Length);

				SvcHttpHandler handler;
				if (!handlers.TryGetValue (path, out handler))
					return;
				handler.Close ();

				handlers.Remove (path);
			}
		}
	}
}
