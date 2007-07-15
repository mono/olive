//
// Microsoft.JScript.Compiler
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
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
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
{
	public class RowanGenerator
	{
		public RowanGenerator(IdentifierMappingTable IDMappingTable, Identifier This, Identifier Underscore, Identifier Arguments, Identifier Eval)
		{
			idMappingTable = IDMappingTable;
			thisIdent = This;
			underscore = Underscore;
			arguments = Arguments;
			eval = Eval;
		}

		private IdentifierMappingTable idMappingTable;
		private	Identifier thisIdent;
		private	Identifier underscore;
		private	Identifier arguments;
		private	Identifier eval;

		public void Bind()
		{
			throw new NotImplementedException();
		}

		# region AST Converter

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
			/*switch (Input.GetType ()) {
				case typeof (ParseTree.BlockStatement):
				case typeof (ParseTree.VariableDeclarationStatement):
				case typeof (ParseTree.IfStatement):
				case typeof (ParseTree.WhileStatement):
				case typeof (ParseTree.DoStatement):
				case typeof (ParseTree.DeclarationForStatement):
				case typeof (ParseTree.DeclarationForInStatement):
				case typeof (ParseTree.ExpressionForInStatement):
				case typeof (ParseTree.ExpressionForStatement):
				case typeof (ParseTree.BreakOrContinueStatement)://cut it
				case typeof (ParseTree.WithStatement):
				case typeof (ParseTree.SwitchStatement):
				case typeof (ParseTree.TryStatement):
				case typeof (ParseTree.ReturnOrThrowStatement): //cut it
				case typeof (ParseTree.FunctionStatement):
				case typeof (ParseTree.LabelStatement):
				case typeof (ParseTree.Statement)://empty or syntaxerror
					break;
				default: //expression statement or syntax error
					break;
			}*/
			throw new NotImplementedException ();
		}

		public Microsoft.Scripting.Internal.Ast.BlockStatement Generate(DList<ParseTree.Statement, ParseTree.BlockStatement> Input, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

		public Microsoft.Scripting.Internal.Ast.Statement Generate(ParseTree.Statement Input, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Location Converter

		public static SourceLocation GetRowanEndLocation(TextSpan Location)
		{
			return new SourceLocation (Location.EndPosition, Location.EndLine, Location.EndColumn);
		}

		public static SourceLocation GetRowanStartLocation(TextSpan Location)
		{
			return new SourceLocation (Location.StartPosition, Location.StartLine, Location.StartColumn);
		}

		public static SourceSpan GetRowanTextSpan(TextSpan Location)
		{
			return GetRowanTextSpan (Location, Location);
		}

		public static SourceSpan GetRowanTextSpan(TextSpan StartLocation, TextSpan EndLocation)
		{
			return new SourceSpan (GetRowanStartLocation (StartLocation), GetRowanEndLocation (EndLocation));
		}

		#endregion

		public void SetGlobals(Microsoft.Scripting.Internal.Ast.CodeBlock Globals)
		{
			throw new NotImplementedException();
		}

	}
}
