//
// Compiler
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
using Microsoft.JScript.Runtime;
using Microsoft.JScript.Compiler.ParseTree;
using SLE = System.Linq.Expressions;
using Microsoft.JScript.Compiler.Helpers;

namespace Microsoft.JScript.Compiler
{
	public class Compiler
	{
		private JSContext context;
		public Compiler(JSContext context)
		{
			this.context = context;
		}

		public SLE.LambdaExpression CompileExpression (char[] Input, ref List<Diagnostic> Diagnostics)
		{
			IdentifierMappingTable idmtable = new IdentifierMappingTable ();
			IdentifierTable idtable = new IdentifierTable ();
			Parser parser = new Parser (Input, idtable, true);
			List<Comment> comments = null;
			BindingInfo bindinginfo = null;
			Expression expr = parser.ParseExpression (ref comments, ref bindinginfo);
			Diagnostics = parser.Diagnostics;
			RowanGenerator gen = new RowanGenerator (idmtable, idtable.InsertIdentifier("this"),  idtable.InsertIdentifier("arguments"));
			return gen.BindAndTransform (expr, bindinginfo);
		}

		public SLE.LambdaExpression CompileProgram (char[] Input, ref List<Diagnostic> Diagnostics, ref bool IncompleteInput)
		{
			return CompileProgram (Input, ref Diagnostics, ref IncompleteInput, false);
		}

		[MonoTODO]
		public SLE.LambdaExpression CompileProgram (char[] Input, ref List<Diagnostic> Diagnostics, ref bool IncompleteInput, bool PrintExpressions)
		{
			IdentifierMappingTable idmtable = new IdentifierMappingTable ();
			IdentifierTable idtable = new IdentifierTable ();
			Parser parser = new Parser (Input, new IdentifierTable (), true);//tode get ecma from somewhere
			List<Comment> comments = null;
			BindingInfo bindinginfo = null;
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments, ref bindinginfo);
			Diagnostics = parser.Diagnostics;
			IncompleteInput = parser.SyntaxIncomplete();
			RowanGenerator gen = new RowanGenerator (idmtable, idtable.InsertIdentifier ("this"), idtable.InsertIdentifier ("arguments"));
			return gen.BindAndTransform (list, bindinginfo, PrintExpressions);
		}
/*
		public MSA.Expression CompileStatement (char[] Input)
		{
			IdentifierMappingTable idmtable = new IdentifierMappingTable ();
			IdentifierTable idtable = new IdentifierTable ();
			Parser parser = new Parser (Input, new IdentifierTable (), true);
			List<Comment> comments = null;
			BindingInfo bindinginfo = null;
			Statement statement = parser.ParseStatement (ref comments);
			RowanGenerator gen = new RowanGenerator (idmtable, idtable.InsertIdentifier ("this"), idtable.InsertIdentifier ("arguments"));
			return gen.Generate (statement);
		}

		public MSA.Expression CompileStatement (string Input)
		{
			return CompileStatement (Input.ToCharArray ());
		}*/
	}
}
