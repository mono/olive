//
// ContractDescriptionGenerator.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2007 Novell, Inc.  http://www.novell.com
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
using System.Collections.ObjectModel;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Description
{
	internal static class ContractDescriptionGenerator
	{
		public static ServiceContractAttribute 
			GetServiceContractAttribute (ref Type contractType)
		{
			Dictionary<Type,ServiceContractAttribute> table =
				new Dictionary<Type,ServiceContractAttribute> ();
			GetServiceContractAttribute (contractType, table);
			if (table.Count == 0)
				throw new InvalidOperationException (String.Format ("Attempted to get contract type from '{0}' which neither is a service contract nor does it inherit service contract.", contractType));
			if (table.Count != 1)
				throw new InvalidOperationException (String.Format ("Type '{0}' contains two or more service contracts at equivalent priority.", contractType));
			IEnumerator<KeyValuePair<Type,ServiceContractAttribute>> en = table.GetEnumerator ();
			en.MoveNext ();
			// Here contractType is set the actual interface type.
			contractType = en.Current.Key;
			return en.Current.Value;
		}

		public static OperationContractAttribute
			GetOperationContractAttribute (MethodBase method)
		{
			object [] matts = method.GetCustomAttributes (
				typeof (OperationContractAttribute), false);
			if (matts.Length == 0)
				return null;
			return (OperationContractAttribute) matts [0];
		}

		static void GetServiceContractAttribute (Type type, Dictionary<Type,ServiceContractAttribute> table)
		{
			for (; type != null; type = type.BaseType) {
				foreach (ServiceContractAttribute i in
					type.GetCustomAttributes (
					typeof (ServiceContractAttribute), true))
					table [type] = i;
				foreach (Type t in type.GetInterfaces ())
					GetServiceContractAttribute (t, table);
			}
		}

		[MonoTODO]
		public static ContractDescription GetContract (
			Type contractType)
		{
			return GetContract (contractType, (Type) null);
		}

		[MonoTODO]
		public static ContractDescription GetContract (
			Type contractType, object serviceImplementation)
		{
			if (serviceImplementation == null)
				throw new ArgumentNullException ("serviceImplementation");
			return GetContract (contractType,
				serviceImplementation.GetType ());
		}

		public static MessageContractAttribute GetMessageContractAttribute (Type type)
		{
			for (Type t = type; t != null; t = t.BaseType) {
				object [] matts = t.GetCustomAttributes (
					typeof (MessageContractAttribute), true);
				if (matts.Length > 0)
					return (MessageContractAttribute) matts [0];
			}
			return null;
		}

		[MonoTODO]
		public static ContractDescription GetContract (
			Type contractType, Type serviceType)
		{
			// FIXME: how serviceType is used?

			ServiceContractAttribute sca = GetServiceContractAttribute (ref contractType);

			string name = sca.Name != null ? sca.Name : contractType.Name;
			string ns = sca.Namespace != null ? sca.Namespace : "http://tempuri.org/";

			ContractDescription cd =
				new ContractDescription (name, ns);
			cd.ContractType = contractType;
			cd.CallbackContractType = sca.CallbackContract;
			cd.SessionMode = sca.SessionMode;
			if (sca.HasProtectionLevel)
				cd.ProtectionLevel = sca.ProtectionLevel;

			// FIXME: load Behaviors

			foreach (MethodInfo mi in contractType.GetMethods ()) {
				OperationContractAttribute oca = GetOperationContractAttribute (mi);
				if (oca == null)
					continue;
				MethodInfo end = null;
				if (oca.AsyncPattern) {
					if (String.Compare ("Begin", 0, mi.Name,0, 5) != 0)
						throw new InvalidOperationException ("For async operation contract patterns, the initiator method name must start with 'Begin'.");
					end = contractType.GetMethod ("End" + mi.Name.Substring (5));
					if (end == null)
						throw new InvalidOperationException ("For async operation contract patterns, corresponding End method is required for each Begin method.");
					if (end.GetCustomAttributes (typeof (OperationContractAttribute), true).Length > 0)
						throw new InvalidOperationException ("Async 'End' method must not have OperationContractAttribute. It is automatically treated as the EndMethod of the corresponding 'Begin' method.");
				}
				OperationDescription od = GetOrCreateOperation (cd, mi, oca, end != null ? end.ReturnType : null);
				if (end != null)
					od.EndMethod = end;
			}

			// FIXME: enable this when I found where this check is needed.
			/*
			if (cd.Operations.Count == 0)
				throw new InvalidOperationException (String.Format ("The service contract type {0} has no operation. At least one operation must exist.", contractType));
			*/
			return cd;
		}

		static OperationDescription GetOrCreateOperation (
			ContractDescription cd, MethodInfo mi,
			OperationContractAttribute oca,
			Type asyncReturnType)
		{
			string name =
				oca.Name != null ? oca.Name :
				oca.AsyncPattern ? mi.Name.Substring (5) :
				mi.Name;

			OperationDescription od = null;
			foreach (OperationDescription iter in cd.Operations) {
				if (iter.Name == name) {
					od = iter;
					break;
				}
			}
			if (od == null) {
				od = new OperationDescription (name, cd);
				od.IsOneWay = oca.IsOneWay;
				if (oca.HasProtectionLevel)
					od.ProtectionLevel = oca.ProtectionLevel;
				od.Messages.Add (GetMessage (cd, mi, oca, true, null));
				if (!od.IsOneWay)
					od.Messages.Add (GetMessage (cd, mi, oca, false, asyncReturnType));
				cd.Operations.Add (od);
			}
			else if (oca.AsyncPattern && od.BeginMethod != null ||
				 !oca.AsyncPattern && od.SyncMethod != null)
				throw new InvalidOperationException ("A contract cannot have two operations that have the identical names and different set of parameters.");

			if (oca.AsyncPattern)
				od.BeginMethod = mi;
			else
				od.SyncMethod = mi;
			od.IsInitiating = oca.IsInitiating;
			od.IsTerminating = oca.IsTerminating;

			foreach (object obj in mi.GetCustomAttributes (true))
				if (obj is IOperationBehavior)
					od.Behaviors.Add ((IOperationBehavior) obj);

			// FIXME: fill KnownTypes, Behaviors and Faults.

			return od;
		}

		static MessageDescription GetMessage (
			ContractDescription cd, MethodInfo mi,
			OperationContractAttribute oca, bool isRequest,
			Type asyncReturnType)
		{
			ParameterInfo [] plist = mi.GetParameters ();
			Type messageType = null;
			string action = isRequest ? oca.Action : oca.ReplyAction;
			MessageContractAttribute mca;

			Type retType = asyncReturnType;
			if (!isRequest && retType == null)
				retType =  mi.ReturnType;

			// If the argument is only one and has [MessageContract]
			// then infer it as a typed messsage
			if (isRequest) {
				mca = plist.Length != 1 ? null :
					GetMessageContractAttribute (plist [0].ParameterType);
				if (mca != null)
					messageType = plist [0].ParameterType;
			}
			else {
				mca = GetMessageContractAttribute (retType);
				if (mca != null)
					messageType = retType;
			}

			if (action == null)
				action = String.Concat (cd.Namespace, 
					cd.Namespace.EndsWith ("/") ? "" : "/", cd.Name,
					"/", mi.Name,
					isRequest ? String.Empty : "Response");

			MessageDescription md = new MessageDescription (
				action, isRequest ? MessageDirection.Input :
				MessageDirection.Output);
			md.MessageType = MessageFilterOutByRef (messageType);
			if (mca != null && mca.HasProtectionLevel)
				md.ProtectionLevel = mca.ProtectionLevel;

			MessageBodyDescription mb = md.Body;
			bool isWrapped = mca == null || mca.IsWrapped;
			if (isWrapped) {
				mb.WrapperName =
					mca != null && mca.WrapperName != null ? mca.WrapperName :
					mi.Name + (isRequest ? String.Empty : "Response");
				mb.WrapperNamespace =
					mca != null && mca.WrapperNamespace != null ? mca.WrapperNamespace :
					cd.Namespace;
			}

			// FIXME: anything to do for ProtectionLevel?

			// Parts
			int index = 0;
			if (mca != null)
				FillMessageBodyDescriptionByContract (
					messageType, md.Body);
			else {
				foreach (ParameterInfo pi in plist) {
					// They are ignored:
					// - out parameter in request
					// - neither out nor ref parameter in reply
					if (isRequest && pi.IsOut)
						continue;
					if (!isRequest && !pi.IsOut && !pi.ParameterType.IsByRef)
						continue;

					MessageBodyMemberAttribute mba = 
						GetMessageBodyMemberAttribute (mi);
					MessagePartDescription pd =
						CreatePartCore (mba, pi.Name,
							"http://tempuri.org/");
					if (mba != null && mba.HasProtectionLevel)
						pd.ProtectionLevel = mba.ProtectionLevel;
					pd.Index = index++;
					pd.Type = MessageFilterOutByRef (pi.ParameterType);
					mb.Parts.Add (pd);

					// AsyncCallback and state are extraneous.
					if (oca.AsyncPattern &&
					    pi.Position == plist.Length - 3)
						break;
				}
			}

			// ReturnValue
			if (!isRequest) {
				MessagePartDescription mp = new MessagePartDescription (mi.Name + "Result", mb.WrapperNamespace);
				mp.Index = 0;
				mp.Type = retType;

				mb.ReturnValue = mp;
			}

			// FIXME: fill headers and properties.

			return md;
		}

		public static void FillMessageBodyDescriptionByContract (
			Type messageType, MessageBodyDescription mb)
		{
			int index = 0;

			// MessageContract-based population
			foreach (MemberInfo bmi in messageType.GetMembers (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
				Type mtype = null;
				string mname = null;
				if (bmi is FieldInfo) {
					FieldInfo fi = (FieldInfo) bmi;
					mtype = fi.FieldType;
					mname = fi.Name;
				}
				else if (bmi is PropertyInfo) {
					PropertyInfo pi = (PropertyInfo) bmi;
					mtype = pi.PropertyType;
					mname = pi.Name;
				}
				else
					continue;

				MessageBodyMemberAttribute mba = 
					GetMessageBodyMemberAttribute (bmi);
				if (mba == null)
					continue;

				MessagePartDescription pd =
					CreatePartCore (mba, mname,
						"http://tempuri.org/");
				pd.Index = index++;
				pd.Type = MessageFilterOutByRef (mtype);
				pd.MemberInfo = bmi;
				mb.Parts.Add (pd);
			}
		}

		static MessagePartDescription CreatePartCore (
			MessageBodyMemberAttribute mba, string defaultName,
			string defaultNamespace)
		{
			string pname = null, pns = null;
			if (mba != null) {
				if (mba.Name != null)
					pname = mba.Name;
				if (mba.Namespace != null)
					pns = mba.Namespace;
			}
			if (pname == null)
				pname = defaultName;
			if (pns == null)
				pns = defaultNamespace;

			return new MessagePartDescription (pname, pns);
		}

		static Type MessageFilterOutByRef (Type type)
		{
			return type == null ? null :
				type.IsByRef ? type.GetElementType () : type;
		}

		static MessageBodyMemberAttribute GetMessageBodyMemberAttribute (MemberInfo mi)
		{
			object [] matts = mi.GetCustomAttributes (
				typeof (MessageBodyMemberAttribute), true);
			return matts.Length > 0 ? (MessageBodyMemberAttribute) matts [0] : null;
		}
	}
}
