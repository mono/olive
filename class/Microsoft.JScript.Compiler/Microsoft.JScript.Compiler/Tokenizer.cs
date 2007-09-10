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
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
{
	public class Tokenizer
	{
		private char[] source;
		private IdentifierTable IDTable;
		private IDictionary<string, Token.Type> keywords;
		private int lineStartPosition;
		private int row;
		private int position;
		private Token current;
		private List<Comment> comments;

		public Tokenizer (char[] Input, IdentifierTable IDTable)
		{
			this.source = Input;
			this.IDTable = IDTable;
			this.position = 0;
			this.row = 1;
			this.lineStartPosition = 0;
			this.comments = new List<Comment> ();
			// move that to static ctor?
			InitKeywords();
		}

		public Token GetNext()
		{
			//Must use CreateToken everytime we create a Token to avoid issue of location
			//But not for token EOF which is more a end of Input than an end of file ;)
			// I can test in create token but it perform better to not test every time 
			//whereas we already know it here

			if (!Advance())
				return new Token (Token.Type.EndOfInput, position, Line, Column, FirstOnLine);

			StripWhiteSpace();

			if (!Advance())
				return new Token (Token.Type.EndOfInput, position, Line, Column, FirstOnLine);

			int c = ReadChar ();
			int next = PeekChar ();

			switch (c)
			{
				case '{':
					return CreateToken (Token.Type.LeftBrace);
				case '}':
					return CreateToken (Token.Type.RightBrace);
				case '(':
					return CreateToken (Token.Type.LeftParenthesis);
				case ')':
					return CreateToken (Token.Type.RightParenthesis);
				case '[':
					return CreateToken (Token.Type.LeftBracket);
				case ']':
					return CreateToken (Token.Type.RightBracket);
				case '.':
					return CreateToken (Token.Type.Dot);
				case ';':
					return CreateToken (Token.Type.Semicolon);
				case ',':
					return CreateToken (Token.Type.Comma);
				case '<':

					if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.LessEqual);
					} else if (next == '<') {
						ReadChar ();
						next = PeekChar ();
						if (next == '=') {
							ReadChar ();
							return CreateToken (Token.Type.LessLessEqual);
						} else {
							return CreateToken (Token.Type.LessLess);
						}
					} else {
						return CreateToken (Token.Type.Less);
					}
				case '>':
					if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.GreaterEqual);
					} else if (next == '>') {
						ReadChar ();
						next = PeekChar ();
						if (next == '=') {
							ReadChar ();
							return CreateToken (Token.Type.GreaterGreaterEqual);
						}
						else if (next == '>') {
							ReadChar ();
							next = PeekChar ();
							if (next == '=') {
								ReadChar ();
								return CreateToken (Token.Type.GreaterGreaterGreaterEqual);
							}
							else
								return CreateToken (Token.Type.GreaterGreaterGreater);
						}
						else {
							return CreateToken (Token.Type.GreaterGreater);
						}
					} else {
						return CreateToken (Token.Type.Greater);
					}
				case '=':
					if (next == '=') {
						ReadChar ();
						next = PeekChar ();
						if (next == '=') {
							ReadChar ();
							return CreateToken (Token.Type.EqualEqualEqual);
						} else {
							return CreateToken (Token.Type.EqualEqual);
						}
					} else {
						return CreateToken (Token.Type.Equal);
					}
				case '!':
					if (next == '=') {
						ReadChar ();
						next = PeekChar ();
						if (next == '=') {
							ReadChar ();
							return CreateToken (Token.Type.BangEqualEqual);
						} else {
							return CreateToken (Token.Type.BangEqual);
						}
					}
					return CreateToken (Token.Type.Bang);
				case '+':
					if (next == '+') {
						ReadChar ();
						return CreateToken (Token.Type.PlusPlus);
					} else if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.PlusEqual);
					} else {
						return CreateToken (Token.Type.Plus);
					}
				case '-':
					if (next == '-') {
						ReadChar ();
						return CreateToken (Token.Type.MinusMinus);
					} else if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.MinusEqual);
					} else {
						return CreateToken (Token.Type.Minus);
					}
				case '*':
					if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.StarEqual);
					} else {
						return CreateToken (Token.Type.Star);
					}
				case '%':
					if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.PercentEqual);
					} else {
						return CreateToken (Token.Type.Percent);
					}
				case '&':
					if (next == '&') {
						ReadChar ();
						return CreateToken (Token.Type.AmpersandAmpersand);
					} else if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.AmpersandEqual);
					} else {
						return CreateToken (Token.Type.Ampersand);
					}
				case '|':
					if (next == '|') {
						ReadChar ();
						return CreateToken (Token.Type.BarBar);
					} else if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.BarEqual);
					} else {
						return CreateToken (Token.Type.Bar);
					}
				case '^':
					if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.CircumflexEqual);
					} else {
						return CreateToken (Token.Type.Circumflex);
					}
				case '~':
					return CreateToken (Token.Type.Tilda);
				case '?':
					return CreateToken (Token.Type.Question);
				case ':':
					return CreateToken (Token.Type.Colon);
				case '/':
					if (next == '=') {
						ReadChar ();
						return CreateToken (Token.Type.DivideEqual);
					} else if (next == '/') {
						// FIXME
						ReadChar ();
						CreateLineComment ();
						return GetNext ();
					} else if (next == '*') {
						ReadChar ();
						CreateBlockComment ();
						return GetNext ();
					} else {
						return CreateToken (Token.Type.Divide);
					}
				case '"':
				case '\'':
					return CreateStringLiteralToken (c);

				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					return CreateNumericLiteralToken (c);

				case 'a':
				case 'b':
				case 'c':
				case 'd':
				case 'e':
				case 'f':
				case 'g':
				case 'h':
				case 'i':
				case 'j':
				case 'k':
				case 'l':
				case 'm':
				case 'n':
				case 'o':
				case 'p':
				case 'q':
				case 'r':
				case 's':
				case 't':
				case 'u':
				case 'v':
				case 'w':
				case 'x':
				case 'y':
				case 'z':
				case 'A':
				case 'B':
				case 'C':
				case 'D':
				case 'E':
				case 'F':
				case 'G':
				case 'H':
				case 'I':
				case 'J':
				case 'K':
				case 'L':
				case 'M':
				case 'N':
				case 'O':
				case 'P':
				case 'Q':
				case 'R':
				case 'S':
				case 'T':
				case 'U':
				case 'V':
				case 'W':
				case 'X':
				case 'Y':
				case 'Z':
				case '$':
				case '_':
					return this.CreateIdentOrKeyword (c);
			}
			return CreateBadToken (((char)c).ToString(),DiagnosticCode.ExtraneousCharacter);
		}

		private Token CreateBadToken (string spelling, DiagnosticCode code)
		{
			return new BadToken (spelling, code, position, Line, Column, FirstOnLine);
		}

		public RegularExpressionLiteralToken ScanRegularExpression (Token Divide)
		{
			int startpos = Divide.StartPosition;
			int startrow = Divide.StartLine;
			int startcol = Divide.StartColumn;

			Token current = Divide[this];
			StringBuilder regexp = new StringBuilder ();
			while (current.Kind == Token.Type.Divide) {
				//get the value of the current token
				for (int i = 0; i < current.Width; i++)
					regexp.Append(source [position + i]);
				current = Divide[this];
			}
			//TODO flags maybe but not always so must peek and not advance
			//TODO firstonline
			return new RegularExpressionLiteralToken (regexp.ToString (), "", position - startpos, startpos, startrow, startcol, false);
		}

		public List<Comment> Comments {
			get { return comments; }
		}

		// we gain that we only move on position (I have see that on an other compiler)
		// but maybe it is better with working with sourcelocation object directely
		// it perform less but more OO ...
		public SourceLocation Position
		{
			get { return new SourceLocation(position, row, position - lineStartPosition +1); }
			set {
				position = value.Index;
				row = value.Line;
				lineStartPosition = position - value.Column + 1;
			}
		}

		#region token

		
		private Token CreateToken (Token.Type tokenType)
		{
			current = new Token (tokenType, position, Line, Column, FirstOnLine);
			return current;
		}

		private Token CreateToken (Token.Type tokenType, string value)
		{
			current = new Token (tokenType, position, Line, Column, FirstOnLine);
			return current;
		}
		
		private Token CreateStringLiteralToken (int q)
		{
			int quote = q;// " or '
			int startPosition = position;
			int startLine = Line;
			int startColumn = Column;
			StringBuilder builder = new StringBuilder ();

			while (Advance ()) {
				int c = PeekChar ();
				if (c == quote)
					break;
				if (c == -1 || c == '\n') {
					return CreateBadToken (builder.ToString(), DiagnosticCode.SyntaxError);
				}
				if (c == '\\') {
					ReadChar ();
					c = PeekChar ();
					switch (c) {
						case '\'':
							c = '\''; 
							break;
						case '"' :
							c = '"';//not sure
							break;
						case '\\':
							c = '\\';
							break;
						case 'b':
							c = '\b';
							break;
						case 'f':
							c = '\f';
							break;
						case 'n':
							c = '\n';
							break;
						case 'r':
							c = '\r';
							break;
						case 't':
							c = '\t';
							break;
						case 'v':
							c = '\v';
							break;
						case 'x'://2 hex digits
							ReadChar ();//next
							int r2 = 0;
							for (int i =0;i<2;i++) {
								ReadChar ();
								int d = PeekChar ();
								if (d >= '0' && d <= '9')
									d -= '0';
								else if (d >= 'A' && d <= 'F')
									d = d - 'A' + 10;
								else if (d >= 'a' && d <= 'f')
									d = d - 'a' + 10;
								else
									return CreateBadToken (builder.ToString(), DiagnosticCode.HexLiteralNoDigits);
								r2 = (r2 << 4) | d;
							}
							c = r2;
							break;
						case 'u'://4 hex digits
							ReadChar ();//next
							int r4 = 0;
							for (int i = 0; i < 4; i++) {
								ReadChar ();
								int d = PeekChar ();
								if (d >= '0' && d <= '9')
									d -= '0';
								else if (d >= 'A' && d <= 'F')
									d = d - 'A' + 10;
								else if (d >= 'a' && d <= 'f')
									d = d - 'a' + 10;
								else
									return CreateBadToken (builder.ToString(), DiagnosticCode.HexLiteralNoDigits);
								r4 = (r4 << 4) | d;
							}
							c = r4;
							break;
						default:
							//TODO 0 [lookahead ?DecimalDigit] or NonEscapeCharacter
							return CreateBadToken (builder.ToString(), DiagnosticCode.HexLiteralNoDigits);
					}
				}
				builder.Append ((char)c);
				ReadChar ();
			}
			//TODO : understand diff between spelling and value here!
			string spelling = builder.ToString();
			string value = builder.ToString ();// same ???

			return new StringLiteralToken (spelling, value, startPosition, startLine, startColumn, FirstOnLine);
		}

		private Token CreateIdentOrKeyword (int first)
		{
			StringBuilder builder = new StringBuilder ();
			builder.Append ((char) first);

			while (Advance ()) {
				int next = PeekChar ();
				if (Char.IsLetterOrDigit ((char) next) || next == '$' || next == '_') {
					builder.Append ((char) next);
					ReadChar ();
					continue;
				}
				break;
			}

			string result = builder.ToString ();

			Token.Type type;
			bool keyword = keywords.TryGetValue (result, out type);

			if (keyword) {
				current = new Token (type, position, Line, Column, FirstOnLine);
			} else {
				this.IDTable.InsertIdentifier (result);
				Identifier id = new Identifier (result, IDTable);
				current = new IdentifierToken (id, result.Length, Token.Type.Identifier, position, Line,
					Column, FirstOnLine);
			}
			
			return current;
		}

		private Token CreateNumericLiteralToken (int first)
		{
			int next = PeekChar ();
			if (first == '0') {
				if (next == 'x' || next == 'X')
					return CreateHexIntegerLiteralToken (first);
				else {
					switch (next) {
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
						case '5':
						case '6':
						case '7':							
							return CreateOctalIntegerLiteralToken (first);
					}//else continue to make a numerical literal token
				}
			}

			StringBuilder builder = new StringBuilder ();
			builder.Append ((char) first);
			int dot = 0;
			int exp = 0;
			while (Advance ()) {
				next = PeekChar ();
				switch (next) {
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9': {
							builder.Append ((char) next);
							ReadChar ();
							continue;
						}
					case '.': {
							ReadChar ();
							dot++;
							builder.Append ((char)next);
							if (dot > 1) {
								current = CreateBadToken (builder.ToString(), DiagnosticCode.MalformedNumericLiteral);
								return current;
							}							
							continue;
						}
					case 'e':
					case 'E': {
							builder.Append ((char)next);
							ReadChar ();
							exp++;
							if (exp > 1) {
								current = CreateBadToken (builder.ToString (), DiagnosticCode.MalformedNumericLiteral);
								return current;
							}
							next = PeekChar ();
							if (next == '+' || next == '-') {
								builder.Append ((char)next);
								ReadChar ();
							}
							continue;
						}
				}
				break;
			}
			string result = builder.ToString ();
			current = new NumericLiteralToken (result, position, Line, Column, FirstOnLine);
			return current;
		}

		private Token CreateOctalIntegerLiteralToken (int first)
		{
			StringBuilder builder = new StringBuilder ();
			builder.Append ((char)first);//0
			double val = 0;

			while (Advance ()) {
				int next = PeekChar ();
				switch (next) {
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7': {
							builder.Append ((char)next);
							val = val * 8 + next - '0';
							ReadChar ();
							continue;
						}
				}
				break;
			}
			string result = builder.ToString ();
			
			current = new OctalIntegerLiteralToken (result, val ,position, Line, Column, FirstOnLine);
			return current;
		}

		private Token CreateHexIntegerLiteralToken (int first)
		{
			StringBuilder builder = new StringBuilder ();
			builder.Append ((char)first);//0
			builder.Append ((char)ReadChar ()); //x or X (ever tested before)
			double val = 0;
			while (Advance ()) {
				int next = PeekChar ();
				switch (next) {
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9': {
							builder.Append ((char)next);
							val = val * 16 + next - '0';
							ReadChar ();
							continue;
						}
					case 'a':
					case 'b':
					case 'c':
					case 'd':
					case 'e':
					case 'f': {
							builder.Append ((char)next);
							val = val * 16 + next - 'a' + 10;
							ReadChar ();
							continue;
						}
					case 'A':
					case 'B':
					case 'C':
					case 'D':
					case 'E':
					case 'F': {
							builder.Append ((char)next);
							val = val * 16 + next - 'A' + 10;
							ReadChar ();
							continue;
						}
				}
				break;
			}
			string result = builder.ToString ();

			current = new HexIntegerLiteralToken (result, val, position, Line, Column, FirstOnLine);
			return current;
		}

		#endregion
		
		private void InitKeywords ()
		{
			keywords = new Dictionary<string, Token.Type> ();
			keywords.Add ("break", Token.Type.@break);
			keywords.Add ("else", Token.Type.@else);
			keywords.Add ("new", Token.Type.@new);
			keywords.Add ("var", Token.Type.var);
			keywords.Add ("case", Token.Type.@case);
			keywords.Add ("finally", Token.Type.@finally);
			keywords.Add ("return", Token.Type.@return);
			keywords.Add ("void", Token.Type.@void);
			keywords.Add ("catch", Token.Type.@catch); 
			keywords.Add ("for", Token.Type.@for);
			keywords.Add ("switch", Token.Type.@switch); 
			keywords.Add ("while", Token.Type.@while);
			keywords.Add ("continue", Token.Type.@continue); 
			keywords.Add ("function", Token.Type.function); 
			keywords.Add ("this", Token.Type.@this); 
			keywords.Add ("with", Token.Type.with);
			keywords.Add ("default", Token.Type.@default); 
			keywords.Add ("if", Token.Type.@if); 
			keywords.Add ("throw", Token.Type.@throw);
			keywords.Add ("delete", Token.Type.delete); 
			keywords.Add ("in", Token.Type.@in); 
			keywords.Add ("try", Token.Type.@try);
			keywords.Add ("do", Token.Type.@do); 
			keywords.Add ("instanceof", Token.Type.instanceof); 
			keywords.Add ("typeof", Token.Type.@typeof);

			//FuturekeyWord
			keywords.Add ("abstract", Token.Type.@abstract);
			keywords.Add ("enum", Token.Type.@enum);
			keywords.Add ("int", Token.Type.@int);
			keywords.Add ("short", Token.Type.@short);
			keywords.Add ("boolean", Token.Type.boolean);
			keywords.Add ("export", Token.Type.export);
			keywords.Add ("interface", Token.Type.@interface);
			keywords.Add ("static", Token.Type.@static);
			keywords.Add ("byte", Token.Type.@byte);
			keywords.Add ("extends", Token.Type.extends);
			keywords.Add ("long", Token.Type.@long);
			keywords.Add ("super", Token.Type.super);
			keywords.Add ("char", Token.Type.@char);
			keywords.Add ("final", Token.Type.final);
			keywords.Add ("native", Token.Type.native);
			keywords.Add ("synchronized", Token.Type.synchronized);
			keywords.Add ("class", Token.Type.@class);
			keywords.Add ("float", Token.Type.@float);
			keywords.Add ("packate", Token.Type.packate);
			keywords.Add ("throws", Token.Type.throws);
			keywords.Add ("const", Token.Type.@const);
			keywords.Add ("goto", Token.Type.@goto);
			keywords.Add ("private", Token.Type.@private);
			keywords.Add ("transient", Token.Type.transient);
			keywords.Add ("debugger", Token.Type.debugger);
			keywords.Add ("implements", Token.Type.implements);
			keywords.Add ("protected", Token.Type.@protected);
			keywords.Add ("volatile", Token.Type.@volatile);
			keywords.Add ("double", Token.Type.@double);
			keywords.Add ("import", Token.Type.import);
			keywords.Add ("public", Token.Type.@public);
		
			//literal
			keywords.Add ("null", Token.Type.@null);
			keywords.Add ("true", Token.Type.@true);
			keywords.Add ("false", Token.Type.@false);

			foreach (string key in keywords.Keys)
				IDTable.InsertIdentifier (key);
		}

		// FIXME '\r'?
		private void StripWhiteSpace ()
		{
			int next = PeekChar ();

			while (next == ' ' || next == '\t' || next == '\r' || next == '\n') {
				ReadChar ();
				next = PeekChar ();
			}
		}

		private void CreateBlockComment ()
		{
			int startPosition = position;
			int startLine = Line;
			int startColumn = Column;
			StringBuilder sb = new StringBuilder ("/*");

			int c = ReadChar ();

			while (c != -1 && (c != '*' || PeekChar () != '/')) {
				sb.Append ((char) c);
				c = ReadChar ();
			}
			sb.Append ("*/");
			if (PeekChar () == '/')
				ReadChar ();

			comments.Add (new Comment (sb.ToString (), new TextSpan (startLine, startColumn, Line, Column, startPosition, position)));
		}

		private void CreateLineComment ()
		{
			StringBuilder sb = new StringBuilder ("//");
			int startPosition = position;

			int c = PeekChar ();

			while (c != -1 && c != '\n') {
				sb.Append ((char) c);
				ReadChar ();
				c = PeekChar ();
			}

			// eat '\n'
			ReadChar ();
		
			comments.Add (new Comment (sb.ToString (), new TextSpan (Line, Column, Line, Column, startPosition,
				position)));
		}

		// Utilities

		int Peek ()
		{
			if (position >= source.Length)
				return -1;

			return source [position];
		}

		int Read ()
		{
			if (position >= source.Length)
				return -1;

			return source [position++];
		}

		int ReadChar ()
		{
			int c = Read ();

			if (c == '\n') {
				++row;
				lineStartPosition = position;
			}

			return c;
		}

		// we can add putback
		int PeekChar ()
		{
			return Peek ();
		}

		bool Advance ()
		{
			return Peek () != -1;
		}

		bool FirstOnLine
		{
			get { return position == lineStartPosition; }
		}

		int Column {
			get { return position - lineStartPosition; }
		}

		int Line {
			get { return row; }
		}
	}
}
