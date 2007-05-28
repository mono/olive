using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Scripting;

namespace Mono.JScript.Compiler
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
			InitKeywords();
		}

		public Token GetNext()
		{
			//Must use CreateToken everytime we create a Token to avoid issue of location
			//But not for token EOF which is more a end of Input than an end of file ;)
			// I can test in create token but it perform better to not test every time 
			//whereas we already know it here

			if (!Advance())
				return new Token (Token.Type.EndOfInput, position, row, position - lineStartPosition, position == lineStartPosition);

			StripWhiteSpace();

			if (!Advance())
				return new Token (Token.Type.EndOfInput, position, row, position - lineStartPosition, position == lineStartPosition);

			char next = source[position];
			int nextPos;
			switch (next)
			{
				case '{':
					return CreateToken(Token.Type.LeftBrace);
				case '}':
					return CreateToken(Token.Type.RightBrace);
				case '(':
					return CreateToken(Token.Type.LeftParenthesis);
				case ')':
					return CreateToken(Token.Type.RightParenthesis);
				case '[':
					return CreateToken(Token.Type.LeftBracket);
				case ']':
					return CreateToken(Token.Type.RightBracket);
				case '.':
					return CreateToken(Token.Type.Dot);
				case ';':
					return CreateToken(Token.Type.SemiColon);
				case ',':
					return CreateToken(Token.Type.Coma);
				case '<':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.LessEqual);
					}
					else if (nextPos < source.Length && source[nextPos] == '<') {
						position++;
						nextPos = position + 1;
						if (nextPos < source.Length && source[nextPos] == '=') {
							position++;
							return CreateToken(Token.Type.LessLessEqual);
						}
						return CreateToken(Token.Type.LessLess);					
					}
					return CreateToken(Token.Type.Less);
				case '>':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.GreaterEqual);
					}
					else if (nextPos < source.Length && source[nextPos] == '>') {
						position++;
						nextPos = position + 1;
						if (nextPos < source.Length && source[nextPos] == '=') {
							position++;
							return CreateToken(Token.Type.GreaterGreaterEqual);
						}
						else if (nextPos < source.Length && source[nextPos] == '>') {
							position++;
							nextPos = position + 1;
							if (nextPos < source.Length && source[nextPos] == '=') {
								position++;
								return CreateToken(Token.Type.GreaterGreaterGreaterEqual);
							}
							return CreateToken(Token.Type.GreaterGreaterGreater);
						}
						return CreateToken(Token.Type.GreaterGreater);
					}
					return CreateToken(Token.Type.Greater);
				case '=':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						nextPos = position + 1;
						if (nextPos < source.Length && source[nextPos] == '=') {
							position++;
							return CreateToken(Token.Type.EqualEqualEqual);
						}
						else
							return CreateToken(Token.Type.EqualEqual);
					}
					else
						return CreateToken(Token.Type.Equal);
				case '!':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						nextPos = position + 1;
						if (nextPos < source.Length && source[nextPos] == '=') {
							position++;
							return CreateToken(Token.Type.BangEqualEqual);
						}
						return CreateToken(Token.Type.BangEqual);
					}
					break;
				case '+':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '+') {
						position++;
						return CreateToken(Token.Type.PlusPlus);
					}
					else if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.PlusEqual);
					}
					return CreateToken(Token.Type.Plus);
				case '-':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '-') {
						position++;
						return CreateToken(Token.Type.MinusMinus);
					}
					else if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.MinusEqual);
					}
					return CreateToken(Token.Type.Minus);
				case '*':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.StarEqual);
					}
					return CreateToken(Token.Type.Star);
				case '%':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.PercentEqual);
					}
					return CreateToken(Token.Type.Percent);
				case '&':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '&') {
						position++;
						return CreateToken(Token.Type.AmpersandAmpersand);
					}
					else if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.AmpersandEqual);
					}
					return CreateToken (Token.Type.Ampersand);
				case '|':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '|') {
						position++;
						return CreateToken(Token.Type.BarBar);
					}
					else if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.BarEqual);
					}
					return CreateToken(Token.Type.Bar);
				case '^':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.CircumflexEqual);
					}
					return CreateToken(Token.Type.Circumflex);
				case '~':
					return CreateToken(Token.Type.Tilda);
				case '?':
					return CreateToken(Token.Type.Question);
				case ':':
					return CreateToken(Token.Type.Colon);
				case '/':
					nextPos = position + 1;
					if (nextPos < source.Length && source[nextPos] == '=') {
						position++;
						return CreateToken(Token.Type.DivideEqual);
					}
					else if (nextPos < source.Length && source[nextPos] == '/') {
						position++;
						CreateLineComment();
						return GetNext();
					}
					else if (nextPos < source.Length && source[nextPos] == '*') {
						position++;
						CreateBlockComment();
						return GetNext ();
					}
					return CreateToken(Token.Type.Divide);
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
					return CreateNumericLiteralToken();

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
					return this.CreateIdentOrKeyword();
			}
			return CreateToken(Token.Type.Bad);
		}

		public RegularExpressionLiteralToken ScanRegularExpression (Token Divide)
		{
			throw new NotImplementedException();
		}
		

		private bool Advance()
		{
			return ((source != null) && position < source.Length);
		}

		public List<Comment> Comments {
			get { return comments; }
		}

		public SourceLocation Position
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		#region token

		private Token CreateToken(Token.Type tokenType)
		{
			current = new Token (tokenType, position, row, position - lineStartPosition, position == lineStartPosition);
			position++;
			return current;
		}

		private Token CreateToken(Token.Type tokenType, string value)
		{
			current = new Token (tokenType, position, row, position - lineStartPosition, position == lineStartPosition);
			position++;
			return current;
		}
		
		private Token CreateIdentOrKeyword()
		{
			StringBuilder builder = new StringBuilder();

			while (Advance()) {
				char next = source[position];
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
					case '9':
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
					case '_': {
							builder.Append(next);
							position++;
							continue;
					}
				}
				break;
			}
			string result = builder.ToString();
			Token.Type type;
			if (keywords.TryGetValue(result, out type)) {
				current = new Token (type, position, row, position - lineStartPosition, position == lineStartPosition);
				return current;
			}
			this.IDTable.InsertIdentifier (result);
			current = new Token (Token.Type.Identifier, position, row, position - lineStartPosition, position == lineStartPosition);
			return current;
		}

		private Token CreateNumericLiteralToken()
		{
			StringBuilder builder = new StringBuilder();
			int dot = 0;

			while (Advance()) {
				char next = source[position];
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
							builder.Append(next);
							position++;
							continue;
						}
					case '.': {
							dot++;
							if (dot > 1) {
								current = new Token (Token.Type.Bad, position, row, position - lineStartPosition, position == lineStartPosition);
								return current;
							}
							builder.Append(next);
							position++;
							continue;
						}
				}
				break;
			}
			string result = builder.ToString();
			current = new Token (Token.Type.NumericLiteral, position, row, position - lineStartPosition, position == lineStartPosition);
			return current;
		}

		#endregion
		
		private void InitKeywords()
		{
			keywords = new Dictionary<string, Token.Type>();
			keywords.Add("break", Token.Type.Break);
			keywords.Add("else", Token.Type.Else);
			keywords.Add("new", Token.Type.New);
			keywords.Add("var", Token.Type.Var);
			keywords.Add("case", Token.Type.Case);
			keywords.Add("finally", Token.Type.Finally);
			keywords.Add("return", Token.Type.Return);
			keywords.Add("void", Token.Type.Void);
			keywords.Add("catch", Token.Type.Catch); 
			keywords.Add("for", Token.Type.For);
			keywords.Add("switch", Token.Type.Switch); 
			keywords.Add("while", Token.Type.While);
			keywords.Add("continue", Token.Type.Continue); 
			keywords.Add("function", Token.Type.Function); 
			keywords.Add("this", Token.Type.This); 
			keywords.Add("with", Token.Type.With);
			keywords.Add("default", Token.Type.Default); 
			keywords.Add("if", Token.Type.If); 
			keywords.Add("throw", Token.Type.Throw);
			keywords.Add("delete", Token.Type.Delete); 
			keywords.Add("in", Token.Type.In); 
			keywords.Add("try", Token.Type.Try);
			keywords.Add("do", Token.Type.Do); 
			keywords.Add("instanceof", Token.Type.Instanceof); 
			keywords.Add("typeof", Token.Type.Typeof);

			//FuturekeyWord
			keywords.Add("abstract", Token.Type.Abstract);
			keywords.Add("enum", Token.Type.Enum);
			keywords.Add("int", Token.Type.Int);
			keywords.Add("short", Token.Type.Short);
			keywords.Add("boolean", Token.Type.Boolean);
			keywords.Add("Export", Token.Type.Export);
			keywords.Add("interface", Token.Type.Interface);
			keywords.Add("static", Token.Type.Static);
			keywords.Add("byte", Token.Type.Byte);
			keywords.Add("extends", Token.Type.Extends);
			keywords.Add("long", Token.Type.Long);
			keywords.Add("super", Token.Type.Super);
			keywords.Add("char", Token.Type.Char);
			keywords.Add("final", Token.Type.Final);
			keywords.Add("native", Token.Type.Native);
			keywords.Add("synchronized", Token.Type.Synchronized);
			keywords.Add("class", Token.Type.Class);
			keywords.Add("float", Token.Type.Float);
			keywords.Add("package", Token.Type.Package);
			keywords.Add("throws", Token.Type.Throws);
			keywords.Add("const", Token.Type.Const);
			keywords.Add("goto", Token.Type.Goto);
			keywords.Add("private", Token.Type.Private);
			keywords.Add("transient", Token.Type.Transient);
			keywords.Add("debugger", Token.Type.Debugger);
			keywords.Add("implements", Token.Type.Implements);
			keywords.Add("protected", Token.Type.Protected);
			keywords.Add("volatile", Token.Type.Volatile);
			keywords.Add("double", Token.Type.Double);
			keywords.Add("import", Token.Type.Import);
			keywords.Add("public", Token.Type.Public);
		
			//literal
			keywords.Add("null", Token.Type.Null);
			keywords.Add("true", Token.Type.True);
			keywords.Add("false", Token.Type.False);

			foreach (string key in keywords.Keys)
				IDTable.InsertIdentifier (key);
		}

		private void StripWhiteSpace()
		{
			char next = source[position];
			while (next == ' ' || next == '\t' || next == '\r' || next == '\n')
			{
				if (next == '\n')
				{
					NextRow();
				}
				else if (next != '\r')
					position++;
				if (position >= source.Length)
					break;
				next = source[position];
			}
		}

		private void NextRow ()
		{
			row++;
			lineStartPosition = position;
			position++;

		}

		private void CreateBlockComment()
		{
			int startPosition = position;
			int startline = row;
			int startcolumn = position - lineStartPosition;
			char next = source[position];
			StringBuilder builder = new StringBuilder ();
			while ((next != '*') && (position + 1 < source.Length) && (source[position + 1] != '/')) {
				builder.Append (next);
				if (next == '\n') {
					row++;
					lineStartPosition = position;
				}
				position++;
				next = source[position];
			}
			comments.Add (new Comment (builder.ToString (), new TextSpan (startline, startcolumn, row, position - lineStartPosition, startPosition, position)));
		}

		private void CreateLineComment()
		{
			int startPosition = position;
			char next = source[position];
			StringBuilder builder = new StringBuilder();
			while (next != '\n' && position < source.Length) {
				builder.Append (next);
				position++;
				next = source[position];
			}
			comments.Add(new Comment(builder.ToString(),new TextSpan(row, startPosition - lineStartPosition, row, position - lineStartPosition, startPosition,position)));
		}
	}
}
