using System.IO;

namespace System.Data.Linq.Design
{
    public class ExtractOptions
    {
        #region Fields
        private int commandTimeout = 30;
        private LanguageType language;
        private TextWriter log;
        private string nspace;
        private bool pluralize;
        private ExtractTypes types;
        private string connType;
        #endregion

        #region Properties
        public int CommandTimeout
        {
            get { return commandTimeout; }
            set { commandTimeout = value; }
        }

        public LanguageType Language
        {
            get { return language; }
            set { language = value; }
        }

        public TextWriter Log
        {
            get { return log; }
            set { log = value; }
        }

        public string Namespace
        {
            get { return nspace; }
            set { nspace = value; }
        }

        public bool Pluralize
        {
            get { return pluralize; }
            set { pluralize = value; }
        }

        public ExtractTypes Types
        {
            get { return types; }
            set { types = value; }
        }

        // This is an addition to the .NET framework for letting
        // the user providing the Type string of the IDbConnection
        public string ConnectionTypeString
        {
            get { return connType; }
            set { connType = value; }
        }
        #endregion
    }
}