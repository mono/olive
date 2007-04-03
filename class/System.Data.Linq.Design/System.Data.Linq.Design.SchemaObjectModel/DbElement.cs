namespace System.Data.Linq.Design
{
    public abstract class DbElement
    {
        #region .ctor
        protected DbElement()
        {
        }
        #endregion

        #region Fields
        public string Access;
        public string Hidden;
        public string Name;
        #endregion
    }
}