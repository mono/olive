namespace Mono.JScript.Compiler
{
	public enum ComparisonResult
	{
		Equal = 0,
		Greater = 1,
		Less = -1
	}

	public enum DiagnosticCode
	{
		SyntaxError,
		SemicolonExpected,
		IdentifierExpected,
		LeftParenExpected,
		LeftBraceExpected,
		CaseOrDefaultExpected,
		SwitchHasMultipleDefaults,
		TryHasNoHandlers,
		BadDivideOrRegularExpressionLiteral,
		EnclosingLabelShadowed,
		NoEnclosingLabel,
		BreakContextInvalid,
		ContinueContextInvalid,
		ContinueLabelInvalid,
		MalformedEscapeSequence,
		HexLiteralNoDigits,
		MalformedNumericLiteral,
		NumericLiteralThenIdentifier,
		UnterminatedStringLiteral,
		UnterminatedComment,
		ExtraneousCharacter
	}
}