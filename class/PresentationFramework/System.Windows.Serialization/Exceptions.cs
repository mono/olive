namespace System.Windows.Serialization {
	public class XamlParseException : Exception {
		public XamlParseException(string message) : base(message)
		{
		}
		
		public XamlParseException(int line, int pos, string message)
			: base(String.Format ("({0},{1}):{2}", line, pos, message))
		{
		}
	}
}
