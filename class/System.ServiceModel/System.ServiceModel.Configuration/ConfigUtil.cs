//
// ConfigUtil.cs
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
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using ConfigurationType = System.Configuration.Configuration;

namespace System.ServiceModel.Configuration
{
	internal static class ConfigUtil
	{
		static ConfigurationType execfg, webcfg;

		static ConfigUtil ()
		{
			execfg = ConfigurationManager.OpenExeConfiguration (ConfigurationUserLevel.None);
			if (execfg == null)
				throw new Exception ("Internal configuration error: cannot load exe config.");
			webcfg = ConfigurationManager.OpenExeConfiguration ("web.config");
			if (webcfg == null)
				throw new Exception ("Internal configuration error: cannot load web config.");
		}

		public static ServiceModelSectionGroup ExeConfig {
			get { return ServiceModelSectionGroup.GetSectionGroup (execfg); }
		}

		public static ServiceModelSectionGroup WebConfig {
			get { return ServiceModelSectionGroup.GetSectionGroup (webcfg); }
		}

		public static BindingsSection ExeBindings {
			get { return BindingsSection.GetSection (execfg); }
		}

		public static BindingsSection WebBindings {
			get { return BindingsSection.GetSection (webcfg); }
		}

		public static Binding CreateBinding (string binding, string bindingConfiguration)
		{
			BindingCollectionElement section = ConfigUtil.ExeConfig.Bindings [binding];
			if (section == null)
				throw new ArgumentException (String.Format ("binding section for {0} was not found.", binding));

			Binding b = (Binding) Activator.CreateInstance (section.BindingType, new object [0]);

			// FIXME: handle ConfiguredBindings.
			//foreach (IBindingConfigurationElement el in section.ConfiguredBindings)
			//	el.ApplyConfiguration (b);

			// FIXME: handle bindingConfiguration

			return b;
		}
	}
}
