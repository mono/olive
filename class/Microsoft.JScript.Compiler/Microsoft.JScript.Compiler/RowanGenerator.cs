using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
{
	public class RowanGenerator
	{
		public RowanGenerator(IdentifierMappingTable IDMappingTable, Identifier This, Identifier Underscore, Identifier Arguments, Identifier Eval)
		{
			throw new NotImplementedException();
		}

		public void Bind()
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.Expression ConvertToObject(Microsoft.Scripting.Internal.Ast.Expression Value)
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.Expression Generate(ParseTree.Expression Input)
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.Statement Generate(ParseTree.FunctionDefinition Input)
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.Statement Generate(ParseTree.Statement Input)
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.BlockStatement Generate(DList<ParseTree.Statement, ParseTree.BlockStatement> Input, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.Statement Generate(ParseTree.Statement Input, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

		public static SourceLocation GetRowanEndLocation(TextSpan Location)
		{
			throw new NotImplementedException();
		}

		public static SourceLocation GetRowanStartLocation(TextSpan Location)
		{
			throw new NotImplementedException();
		}

		public static SourceSpan GetRowanTextSpan(TextSpan Location)
		{
			throw new NotImplementedException();
		}

		public static SourceSpan GetRowanTextSpan(TextSpan StartLocation, TextSpan EndLocation)
		{
			throw new NotImplementedException();
		}

		public void SetGlobals(Microsoft.Scripting.Internal.Ast.CodeBlock Globals)
		{
			throw new NotImplementedException();
		}

	}
}
