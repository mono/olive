//
// outline -- support for rendering in monop
// Some code stolen from updater.cs in monodoc.
//
// Authors:
//	Ben Maurer (bmaurer@users.sourceforge.net)
//
// (C) 2004 Ben Maurer
//

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
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
	
public class Outline {
	
	Options options;
	IndentedTextWriter o;
	Type t;
	
	public Outline (Type t, TextWriter output, Options options)
	{
		this.t = t;
		this.o = new IndentedTextWriter (output, "\t");
		this.options = options;
	}

	public void OutlineType ()
        {
		bool first;
		
		o.Write (GetTypeVisibility (t));
		
		if (t.IsClass && !t.IsSubclassOf (typeof (System.MulticastDelegate))) {
			if (t.IsSealed)
				o.Write (t.IsAbstract ? " static" : " sealed");
			else if (t.IsAbstract)
				o.Write (" abstract");
		}
		
		o.Write (" ");
		o.Write (GetTypeKind (t));
		o.Write (" ");
		
		Type [] interfaces = (Type []) Comparer.Sort (TypeGetInterfaces (t, options.DeclaredOnly));
		Type parent = t.BaseType;

		if (t.IsSubclassOf (typeof (System.MulticastDelegate))) {
			return;
		}
		
		o.Write (GetTypeName (t));
		if (((parent != null && parent != typeof (object) && parent != typeof (ValueType)) || interfaces.Length != 0) && ! t.IsEnum) {
			first = true;
			o.Write (" : ");
			
			if (parent != null && parent != typeof (object) && parent != typeof (ValueType)) {
				o.Write (FormatType (parent));
				first = false;
			}
			
			foreach (Type intf in interfaces) {
				if (!first) o.Write (", ");
				first = false;
				
				o.Write (FormatType (intf));
			}
		}

		if (t.IsEnum) {
			Type underlyingType = Enum.GetUnderlyingType (t);
			if (underlyingType != typeof (int))
				o.Write (" : {0}", FormatType (underlyingType));
		}
#if NET_2_0
		WriteGenericConstraints (t.GetGenericArguments ());
#endif		
		o.WriteLine (" {");
		o.Indent++;

		if (t.IsEnum) {
			bool is_first = true;
			foreach (FieldInfo fi in t.GetFields (BindingFlags.Public | BindingFlags.Static)) {
				
				if (! is_first)
					o.WriteLine (",");
				is_first = false;
				o.Write (fi.Name);
			}
			o.WriteLine ();
			o.Indent--; o.WriteLine ("}");
			return;
		}

		first = true;

		foreach (FieldInfo fi in t.GetFields (DefaultFlags)) {
			
			if (! ShowMember (fi))
				continue;
			
			if (first)
				o.WriteLine ();
			first = false;
			
			OutlineField (fi);
			
			o.WriteLine ();
		}

		first = true;

		foreach (Type ntype in Comparer.Sort (t.GetNestedTypes (DefaultFlags))) {
			
			if (! ShowMember (ntype))
				continue;
			
			if (first)
				o.WriteLine ();
			first = false;
			
			new Outline (ntype, o, options).OutlineType ();
		}
		
		o.Indent--; o.WriteLine ("}");
	}
	
	BindingFlags DefaultFlags {
		get {
			BindingFlags f = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			
			if (options.DeclaredOnly)
				f |= BindingFlags.DeclaredOnly;
			
			return f;
		}
	}

	void OutlineField (FieldInfo fi)
	{
		if (fi.IsPublic)   o.Write ("public ");
		if (fi.IsFamily)   o.Write ("protected ");
		if (fi.IsPrivate)  o.Write ("private ");
		if (fi.IsAssembly) o.Write ("internal ");
		if (fi.IsLiteral)  o.Write ("const ");
		else if (fi.IsStatic) o.Write ("static ");
		if (fi.IsInitOnly) o.Write ("readonly ");

		o.Write (FormatType (fi.FieldType));
		o.Write (" ");
		o.Write (fi.Name);
		if (fi.IsLiteral) { 
			object v = fi.GetValue (this);

			// TODO: Escape values here
			o.Write (" = ");
			if (v is char)
				o.Write ("'{0}'", v);
			else if (v is string)
				o.Write ("\"{0}\"", v);
			else
				o.Write (fi.GetValue (this));
		}
		else if (fi.IsStatic) {
			object fv = fi.GetValue (null);
			if (fv != null) {
				if (fi.FieldType == typeof (RoutedUICommand)) {
				}
				else if (fi.FieldType == typeof (RoutedEvent)) {
					RoutedEvent re = (RoutedEvent)fv;
					o.Write (" = RoutedEvent ('{0}', {1}, {2}, {3})",
						 re.Name, re.HandlerType.Name, re.OwnerType.Name, re.RoutingStrategy);
				}
				if (fi.FieldType == typeof (DependencyProperty)) {
					DependencyProperty dp = (DependencyProperty)fv;
					o.Write (" = DependencyProperty ('{0}', {1}, {2})",
						 dp.Name, dp.PropertyType.Name, dp.OwnerType.Name);

					if (options.PropMetadata) {
						PropertyMetadata pm = dp.DefaultMetadata;
						PropertyMetadata type_pm;

						if (pm != null) {
							o.Indent++;
							o.WriteLine (";");
							o.Write ("DefaultMetadata = (default={0}, has_changed_cb={1}, has_coerce_cb={2})",
								 pm.DefaultValue == null ? "<null>" : pm.DefaultValue.ToString(),
								 pm.PropertyChangedCallback != null,
								 pm.CoerceValueCallback != null);
						 
							o.Indent--;
						}

						type_pm = dp.GetMetadata (t);
						if (type_pm != null && type_pm != pm) {
							o.Indent++;
							o.WriteLine (";");
							o.Write ("MetaData for {3} = (default={0}, has_changed_cb={1}, has_coerce_cb={2})",
								 type_pm.DefaultValue == null ? "<null>" : type_pm.DefaultValue.ToString(),
								 type_pm.PropertyChangedCallback != null,
								 pm.CoerceValueCallback != null,
								 t.Name);
						 
							o.Indent--;
						}
					}
				}
			}
		}
		o.Write (";");
	}

	static string GetTypeKind (Type t)
	{
		if (t.IsEnum)
			return "enum";
		if (t.IsClass) {
			if (t.IsSubclassOf (typeof (System.MulticastDelegate)))
				return "delegate";
			else
				return "class";
		}
		if (t.IsInterface)
			return "interface";
		if (t.IsValueType)
			return "struct";
		return "class";
	}
	
	static string GetTypeVisibility (Type t)
	{
                switch (t.Attributes & TypeAttributes.VisibilityMask){
                case TypeAttributes.Public:
                case TypeAttributes.NestedPublic:
                        return "public";

                case TypeAttributes.NestedFamily:
                case TypeAttributes.NestedFamANDAssem:
                case TypeAttributes.NestedFamORAssem:
                        return "protected";

                default:
                        return "internal";
                }
	}

	string FormatGenericParams (Type [] args)
	{
		StringBuilder sb = new StringBuilder ();
		if (args.Length == 0)
			return "";
		
		sb.Append ("<");
		for (int i = 0; i < args.Length; i++) {
			if (i > 0)
				sb.Append (",");
			sb.Append (FormatType (args [i]));
		}
		sb.Append (">");
		return sb.ToString ();
	}
	
	// TODO: fine tune this so that our output is less verbose. We need to figure
	// out a way to do this while not making things confusing.
	string FormatType (Type t)
	{
		string type = GetFullName (t);
		
		if (!type.StartsWith ("System.")) {
			if (t.Namespace == this.t.Namespace)
				return t.Name;
			return type;
		}
		
		if (t.HasElementType) {
			Type et = t.GetElementType ();
			if (t.IsArray)
				return FormatType (et) + " []";
			if (t.IsPointer)
				return FormatType (et) + " *";
			if (t.IsByRef)
				return "ref " + FormatType (et);
		}
	
		switch (type) {
		case "System.Byte": return "byte";
		case "System.SByte": return "sbyte";
		case "System.Int16": return "short";
		case "System.Int32": return "int";
		case "System.Int64": return "long";
			
		case "System.UInt16": return "ushort";
		case "System.UInt32": return "uint";
		case "System.UInt64": return "ulong";
			
		case "System.Single":  return "float";
		case "System.Double":  return "double";
		case "System.Decimal": return "decimal";
		case "System.Boolean": return "bool";
		case "System.Char":    return "char";
		case "System.String":  return "string";
			
		case "System.Object":  return "object";
		case "System.Void":  return "void";
		}
	
		if (type.LastIndexOf(".") == 6)
			return type.Substring(7);

		//
		// If the namespace of the type is the namespace of what
		// we are printing (or is a member of one if its children
		// don't print it. This basically means that in C# we would
		// automatically get the namespace imported by virtue of the
		// namespace {} block.
		//	
		if (this.t.Namespace.StartsWith (t.Namespace + ".") || t.Namespace == this.t.Namespace)
			return type.Substring (t.Namespace.Length + 1);
	
		return type;
	}

	public static string RemoveGenericArity (string name)
	{
		int start = 0;
		StringBuilder sb = new StringBuilder ();
		while (start < name.Length) {
			int pos = name.IndexOf ('`', start);
			if (pos < 0) {
				sb.Append (name.Substring (start));
				break;
			}
			sb.Append (name.Substring (start, pos-start));

			pos++;

			while ((pos < name.Length) && Char.IsNumber (name [pos]))
				pos++;

			start = pos;
		}

		return sb.ToString ();
	}

	string GetTypeName (Type t)
	{
		StringBuilder sb = new StringBuilder ();
		GetTypeName (sb, t);
		return sb.ToString ();
	}

	void GetTypeName (StringBuilder sb, Type t)
	{
		sb.Append (RemoveGenericArity (t.Name));
#if NET_2_0
		sb.Append (FormatGenericParams (t.GetGenericArguments ()));
#endif
	}

	string GetFullName (Type t)
	{
		StringBuilder sb = new StringBuilder ();
		GetFullName_recursed (sb, t, false);
		return sb.ToString ();
	}

	void GetFullName_recursed (StringBuilder sb, Type t, bool recursed)
	{
#if NET_2_0
		if (t.IsGenericParameter) {
			sb.Append (t.Name);
			return;
		}
#endif

		if (t.DeclaringType != null) {
			GetFullName_recursed (sb, t.DeclaringType, true);
			sb.Append (".");
		}

		if (!recursed) {
			string ns = t.Namespace;
			if ((ns != null) && (ns != "")) {
				sb.Append (ns);
				sb.Append (".");
			}
		}

		GetTypeName (sb, t);
	}

#if NET_2_0
	void WriteGenericConstraints (Type [] args)
	{

		foreach (Type t in args) {
			bool first = true;
			Type[] ifaces = TypeGetInterfaces (t, true);
			
			GenericParameterAttributes attrs = t.GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;
			GenericParameterAttributes [] interesting = {
				GenericParameterAttributes.ReferenceTypeConstraint,
				GenericParameterAttributes.NotNullableValueTypeConstraint,
				GenericParameterAttributes.DefaultConstructorConstraint
			};
			
			if (t.BaseType != typeof (object) || ifaces.Length != 0 || attrs != 0) {
				o.Write (" where ");
				o.Write (FormatType (t));
				o.Write (" : ");
			}

			if (t.BaseType != typeof (object)) {
				o.Write (FormatType (t.BaseType));
				first = false;
			}

			foreach (Type iface in ifaces) {
				if (!first)
					o.Write (", ");
				first = false;
				
				o.Write (FormatType (iface));
			}

			foreach (GenericParameterAttributes a in interesting) {
				if ((attrs & a) == 0)
					continue;
				
				if (!first)
					o.Write (", ");
				first = false;
				
				switch (a) {
				case GenericParameterAttributes.ReferenceTypeConstraint:
					o.Write ("class");
					break;
				case GenericParameterAttributes.NotNullableValueTypeConstraint:
					o.Write ("struct");
					break;
				case GenericParameterAttributes.DefaultConstructorConstraint:
					o.Write ("new ()");
					break;
				}
			}
		}
	}
#endif
 
	string OperatorFromName (string name)
	{
		switch (name) {
		case "op_UnaryPlus": return "+";
		case "op_UnaryNegation": return "-";
		case "op_LogicalNot": return "!";
		case "op_OnesComplement": return "~";
		case "op_Increment": return "++";
		case "op_Decrement": return "--";
		case "op_True": return "true";
		case "op_False": return "false";
		case "op_Addition": return "+";
		case "op_Subtraction": return "-";
		case "op_Multiply": return "*";
		case "op_Division": return "/";
		case "op_Modulus": return "%";
		case "op_BitwiseAnd": return "&";
		case "op_BitwiseOr": return "|";
		case "op_ExclusiveOr": return "^";
		case "op_LeftShift": return "<<";
		case "op_RightShift": return ">>";
		case "op_Equality": return "==";
		case "op_Inequality": return "!=";
		case "op_GreaterThan": return ">";
		case "op_LessThan": return "<";
		case "op_GreaterThanOrEqual": return ">=";
		case "op_LessThanOrEqual": return "<=";
		default: return name;
		}
	}

	bool MethodIsExplicitIfaceImpl (MethodBase mb)
	{
		if (!(mb.IsFinal && mb.IsVirtual && mb.IsPrivate))
			return false;
		
		// UGH msft has no way to get the info about what method is
		// getting overriden. Another reason to use cecil :-)
		//
		//MethodInfo mi = mb as MethodInfo;
		//if (mi == null)
		//	return false;
		//
		//Console.WriteLine (mi.GetBaseDefinition ().DeclaringType);
		//return mi.GetBaseDefinition ().DeclaringType.IsInterface;
		
		// So, we guess that virtual final private methods only come
		// from ifaces :-)
		return true;
	}
	
	bool ShowMember (MemberInfo mi)
	{
		if (mi.MemberType == MemberTypes.Constructor && ((MethodBase) mi).IsStatic)
			return false;
		
		if (options.ShowPrivate)
			return true;

		if (options.FilterObsolete && mi.IsDefined (typeof (ObsoleteAttribute), false))
			return false;
		
		switch (mi.MemberType) {
		case MemberTypes.Constructor:
		case MemberTypes.Method:
			MethodBase mb = mi as MethodBase;
		
			if (mb.IsFamily || mb.IsPublic || mb.IsFamilyOrAssembly)
				return true;
			
			if (MethodIsExplicitIfaceImpl (mb))
				return true;
					
			return false;
		
		
		case MemberTypes.Field:
			FieldInfo fi = mi as FieldInfo;
		
			if (fi.IsFamily || fi.IsPublic || fi.IsFamilyOrAssembly)
				return true;
			
			return false;
		
		
		case MemberTypes.NestedType:
		case MemberTypes.TypeInfo:
			Type t = mi as Type;
		
			switch (t.Attributes & TypeAttributes.VisibilityMask){
			case TypeAttributes.Public:
			case TypeAttributes.NestedPublic:
			case TypeAttributes.NestedFamily:
			case TypeAttributes.NestedFamORAssem:
				return true;
			}
			
			return false;
		}
		
		// What am I !!!
		return true;
	}

	static Type [] TypeGetInterfaces (Type t, bool declonly)
	{
		Type [] ifaces = t.GetInterfaces ();
		if (! declonly)
			return ifaces;

		// Handle Object. Also, optimize for no interfaces
		if (t.BaseType == null || ifaces.Length == 0)
			return ifaces;

		ArrayList ar = new ArrayList ();

		foreach (Type i in ifaces)
			if (! i.IsAssignableFrom (t.BaseType))
				ar.Add (i);

		return (Type []) ar.ToArray (typeof (Type));
	}
}

public class Comparer : IComparer  {
	delegate int ComparerFunc (object a, object b);
	
	ComparerFunc cmp;
	
	Comparer (ComparerFunc f)
	{
		this.cmp = f;
	}
	
	public int Compare (object a, object b)
	{
		return cmp (a, b);
	}

	static int CompareType (object a, object b)
	{
		Type type1 = (Type) a;
		Type type2 = (Type) b;

		if (type1.IsSubclassOf (typeof (System.MulticastDelegate)) != type2.IsSubclassOf (typeof (System.MulticastDelegate)))
				return (type1.IsSubclassOf (typeof (System.MulticastDelegate)))? -1:1;
		return string.Compare (type1.Name, type2.Name);
			
	}

	static Comparer TypeComparer = new Comparer (new ComparerFunc (CompareType));

	static Type [] Sort (Type [] types)
	{
		Array.Sort (types, TypeComparer);
		return types;
	}
	
	static int CompareMemberInfo (object a, object b)
	{
		return string.Compare (((MemberInfo) a).Name, ((MemberInfo) b).Name);
	}
	
	static Comparer MemberInfoComparer = new Comparer (new ComparerFunc (CompareMemberInfo));
	
	public static MemberInfo [] Sort (MemberInfo [] inf)
	{
		Array.Sort (inf, MemberInfoComparer);
		return inf;
	}
	
	static int CompareMethodBase (object a, object b)
	{
		MethodBase aa = (MethodBase) a, bb = (MethodBase) b;
		
		if (aa.IsStatic == bb.IsStatic) {
			int c = CompareMemberInfo (a, b);
			if (c != 0)
				return c;
			ParameterInfo [] ap, bp;

			//
			// Sort overloads by the names of their types
			// put methods with fewer params first.
			//
			
			ap = aa.GetParameters ();
			bp = bb.GetParameters ();
			int n = Math.Min (ap.Length, bp.Length);

			for (int i = 0; i < n; i ++)
				if ((c = CompareType (ap [i].ParameterType, bp [i].ParameterType)) != 0)
					return c;

			return ap.Length.CompareTo (bp.Length);
		}
		if (aa.IsStatic)
			return -1;
		
		return 1;
	}
	
	static Comparer MethodBaseComparer = new Comparer (new ComparerFunc (CompareMethodBase));
	
	public static MethodBase [] Sort (MethodBase [] inf)
	{
		Array.Sort (inf, MethodBaseComparer);
		return inf;
	}
	
	static int ComparePropertyInfo (object a, object b)
	{
		PropertyInfo aa = (PropertyInfo) a, bb = (PropertyInfo) b;
		
		bool astatic = (aa.CanRead ? aa.GetGetMethod (true) : aa.GetSetMethod (true)).IsStatic;
		bool bstatic = (bb.CanRead ? bb.GetGetMethod (true) : bb.GetSetMethod (true)).IsStatic;
		
		if (astatic == bstatic)
			return CompareMemberInfo (a, b);
		
		if (astatic)
			return -1;
		
		return 1;
	}
	
	static Comparer PropertyInfoComparer = new Comparer (new ComparerFunc (ComparePropertyInfo));
	
	public static PropertyInfo [] Sort (PropertyInfo [] inf)
	{
		Array.Sort (inf, PropertyInfoComparer);
		return inf;
	}
	
	static int CompareEventInfo (object a, object b)
	{
		EventInfo aa = (EventInfo) a, bb = (EventInfo) b;
		
		bool astatic = aa.GetAddMethod (true).IsStatic;
		bool bstatic = bb.GetAddMethod (true).IsStatic;
		
		if (astatic == bstatic)
			return CompareMemberInfo (a, b);
		
		if (astatic)
			return -1;
		
		return 1;
	}
	
	static Comparer EventInfoComparer = new Comparer (new ComparerFunc (CompareEventInfo));
	
	public static EventInfo [] Sort (EventInfo [] inf)
	{
		Array.Sort (inf, EventInfoComparer);
		return inf;
	}
}
