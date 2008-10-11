using System;
using System.Collections.Generic;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Ast;
using Microsoft.Scripting.Generation;

namespace Microsoft.JScript.Runtime.Calls {

	public class JSBinder : ActionBinder {

		public JSBinder (CodeContext context)
			: base (context)
		{
		}
		
		public override MemberGroup GetMember (DynamicAction action, Type type, string name)
		{
			throw new NotImplementedException ();
		}
		
		public override bool CanConvertFrom (Type fromType, Type toType, NarrowingLevel level)
		{
			throw new NotImplementedException ();
		}

		public override object Convert (object obj, Type toType)
		{
			throw new NotImplementedException ();
		}

		public override Expression MakeMissingMemberError<T> (StandardRule <T> rule, Type type, string name)
		{
			throw new NotImplementedException ();
		}

		public override Expression ConvertExpression (Expression expr, Type toType)
		{
			throw new NotImplementedException ();
		}

		protected override StandardRule<T> MakeRule<T> (CodeContext callerContext, DynamicAction action, object [] args)
		{
			throw new NotImplementedException ();
		}

		public override bool PreferConvert (Type t1, Type t2)
		{
			throw new NotImplementedException ();
		}

		public override Type SelectBestConversionFor (Type actualType, Type candidateOne, Type candidateTwo, NarrowingLevel level)
		{
			throw new NotImplementedException ();
		}
		
		protected override IList<Type> GetExtensionTypes (Type t)
		{
			throw new NotImplementedException ();
		}
	}
}
