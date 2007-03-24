namespace System.Data.Linq
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class DatabaseAttribute : Attribute
    {
        #region .ctor
        public DatabaseAttribute()
        {
        }
        #endregion

        #region Fields
        private string name;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
    }
}