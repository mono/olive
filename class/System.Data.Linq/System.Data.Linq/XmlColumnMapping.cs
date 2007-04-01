namespace System.Data.Linq
{
    class XmlColumnMapping : XmlMemberMapping
    {
        #region .ctor
        public XmlColumnMapping(string member)
            : base(member)
        {
        }
        #endregion

        #region Fields
        private AutoSync autoSync;
        private bool? canBeNull;
        private string dbType;
        private string expression;
        private bool dBGenerated;
        private bool discriminator;
        private bool primaryKey;
        private bool version;
        private UpdateCheck updateCheck;
        #endregion
    }
}