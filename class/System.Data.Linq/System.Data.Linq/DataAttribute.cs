namespace System.Data.Linq
{
    public abstract class DataAttribute : Attribute
    {
        #region .ctor
        protected DataAttribute()
        {
        }
        #endregion

        #region Fields
        private string name;
        private string storage;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Storage
        {
            get { return storage; }
            set { storage = value; }
        }
        #endregion
    }
}