using System;

namespace System.Data.Linq
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class AssociationAttribute : DataAttribute
    {
        #region .ctor
        public AssociationAttribute()
        {
        }
        #endregion

        #region Fields
        private string deleteRule;
        private bool fkey;
        private bool unique;
        private string otherKey;
        private string thisKey;
        #endregion

        #region Properties
        public string DeleteRule
        {
            get { return deleteRule; }
            set { deleteRule = value; }
        }

        public bool IsForeignKey 
        {
            get { return fkey; }
            set { fkey = value; }
        }

        public bool IsUnique
        {
            get { return this.unique; }
            set { unique = value; }
        }

        public string OtherKey
        {
            get { return this.otherKey; }
            set { otherKey = value; }
        }

        public string ThisKey
        {
            get { return thisKey; }
            set { thisKey = value; }
        }
        #endregion
    }
}
