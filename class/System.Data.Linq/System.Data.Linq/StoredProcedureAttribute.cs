namespace System.Data.Linq
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class StoredProcedureAttribute : Attribute
    {
        #region .ctor
        public StoredProcedureAttribute()
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