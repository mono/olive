namespace System.Data.Linq
{
    class XmlMemberMapping
    {
        #region .ctor
        protected XmlMemberMapping(string member)
        {
            this.member = member;
        }
        #endregion

        #region Fields
        private string member;
        private string name;
        private string storage;
        #endregion

        #region Properties
        public string MemberName
        {
            get { return member; }
        }

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