namespace System.Data.Linq
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ColumnAttribute : DataAttribute
    {
        #region .ctor
        public ColumnAttribute()
        {
        }
        #endregion

        #region Fields
        private AutoSync autoSync = ~AutoSync.Never;
        private bool canBeNull = true;
        private bool canBeNullSet;
        private UpdateCheck check = UpdateCheck.Always;
        private string dbtype;
        private string expression;
        private bool dbGen;
        private bool discrim;
        private bool pkey;
        private bool version;
        #endregion

        #region Properties
        public AutoSync AutoSync
        {
            get { return autoSync; }
            set { autoSync = value; }
        }

        public bool CanBeNull
        {
            get { return canBeNull; }
            set
            {
                canBeNullSet = true;
                canBeNull = value;
            }
        }

        internal bool CanBeNullSet
        {
            get { return canBeNullSet; }
        }

        public string DBType
        {
            get { return dbtype; }
            set { dbtype = value; }
        }

        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public bool IsDBGenerated
        {
            get { return dbGen; }
            set { dbGen = value; }
        }

        public bool IsDiscriminator
        {
            get { return discrim; }
            set { discrim = value; }
        }

        public bool IsPrimaryKey
        {
            get { return pkey; }
            set { pkey = value; }
        }

        public bool IsVersion
        {
            get { return version; }
            set { version = value; }
        }

        public UpdateCheck UpdateCheck
        {
            get { return check; }
            set { check = value; }
        }
        #endregion
    }
}