using System.Text;

namespace System.Data.Linq.Design
{
    public class ResultFile
    {
        #region Fields
        private Encoding encoding;
        private string fileContent;
        private string fileName;
        private bool primary;
        private bool sourceFile;
        #endregion

        #region Properties
        public Encoding Encoding
        {
            get { return encoding; }
            set { encoding = value; }
        }

        public string FileContent
        {
            get { return fileContent; }
            set { fileContent = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public bool IsPrimary
        {
            get { return primary; }
            set { primary = value; }
        }

        public bool IsSourceFile
        {
            get { return sourceFile; }
            set { sourceFile = value; }
        }
        #endregion
    }
}