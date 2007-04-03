namespace System.Data.Linq.Design
{
    public class GenerateOptions
    {
        #region Fields
        private string nspace;
        private string resBaseFN;
        #endregion

        #region Properties
        public string Namespace
        {
            get { return nspace; }
            set { nspace = value; }
        }

        public string ResultBaseFileName
        {
            get { return resBaseFN; }
            set { resBaseFN = value; }
        }
        #endregion
    }
}