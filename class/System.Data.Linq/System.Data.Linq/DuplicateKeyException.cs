namespace System.Data.Linq
{
    public class DuplicateKeyException : InvalidOperationException
    {
        #region .ctor
        public DuplicateKeyException()
        {
        }

        public DuplicateKeyException(string message)
            : base(message)
        {
        }

        public DuplicateKeyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        #endregion
    }
}