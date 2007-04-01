namespace System.Data.Linq
{
    class XmlAssociationMapping : XmlMemberMapping
    {
        #region .ctor
        public XmlAssociationMapping(string member)
            : base(member)
        {
        }
        #endregion

        #region Fields
        private string deleteRule;
        private bool foreignKey;
        private bool unique;
        private string otherKey;
        private string otherTableName;
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
            get { return foreignKey; }
            set { foreignKey = value; }
        }

        public bool IsUnique
        {
            get { return unique; }
            set { unique = value; }
        }

        public string OtherKey
        {
            get { return otherKey; }
            set { otherKey = value; }
        }

        public string OtherTableName
        {
            get { return otherTableName; }
            set { otherTableName = value; }
        }

        public string ThisKey
        {
            get { return thisKey; }
            set { thisKey = value; }
        }
        #endregion
    }
}