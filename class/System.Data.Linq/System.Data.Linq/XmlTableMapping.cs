namespace System.Data.Linq
{
    class XmlTableMapping
    {
        #region .ctor
        public XmlTableMapping(string name)
        {
            this.name = name;
        }
        #endregion

        #region Fields
        private string name;
        private XmlTypeMapping rowType;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
        }

        public XmlTypeMapping RowType
        {
            get { return rowType; }
            set { rowType = value; }
        }
        #endregion
    }
}