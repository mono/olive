//
// QueryStringConverter.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
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
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace System.ServiceModel.Dispatcher
{
	public class QueryStringConverter
	{
		// "Service Operation Parameters and URLs"
		// http://msdn2.microsoft.com/en-us/library/bb412172.aspx
		public virtual bool CanConvert (Type type)
		{
			switch (Type.GetTypeCode (type)) {
			case TypeCode.DBNull:
			case TypeCode.Empty:
				return false;
			case TypeCode.Object:
				if (type == typeof (Guid))
					return true;
				if (type.GetCustomAttributes (typeof (TypeConverterAttribute), true).Length > 0)
					return true;
				return false;
			default:
				return true;
			}
		}

		[MonoTODO]
		public virtual object ConvertStringToValue (string parameter, Type parameterType)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual string ConvertValueToString (object parameter, Type parameterType)
		{
			throw new NotImplementedException ();
		}
	}
}
