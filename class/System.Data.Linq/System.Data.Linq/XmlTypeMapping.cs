using System.Collections.Generic;

namespace System.Data.Linq
{
    class XmlTypeMapping
    {
        #region .ctor
        public XmlTypeMapping(string name)
        {
            this.name = name;
        }
        #endregion

        #region Fields
        private string name;
        private string inheritanceCode;
        private bool inheritanceDefault;
        private List<XmlTypeMapping> derived = new List<XmlTypeMapping>();
        private List<XmlMemberMapping> members = new List<XmlMemberMapping>();
        #endregion

        #region Properties
        public string TypeName
        {
            get { return name; }
        }

        public string InheritanceCode
        {
            get { return inheritanceCode; }
            set { inheritanceCode = value; }
        }

        public bool IsInheritanceDefault
        {
            get { return inheritanceDefault; }
            set { inheritanceDefault = value; }
        }

        public List<XmlTypeMapping> Derived
        {
            get { return derived; }
        }
        #endregion
    }
}