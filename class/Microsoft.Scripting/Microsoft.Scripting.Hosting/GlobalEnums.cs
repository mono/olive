public enum TokenCategory
{
	None,
	EndOfStream,
	WhiteSpace,
	Comment,
	LineComment,
	DocComment,
	NumericLiteral,
	CharacterLiteral,
	StringLiteral,
	RegularExpressionLiteral,
	Keyword,
	Directive,
	Operator,
	Delimiter,
	Identifier,
	Grouping,
	Error,
	LanguageDefined

}
public enum TokenTriggers
{
	MatchBraces,
	MemberSelect,
	MethodTip,
	None,
	Parameter,
	ParameterEnd,
	ParameterNext,
	ParameterStart

}