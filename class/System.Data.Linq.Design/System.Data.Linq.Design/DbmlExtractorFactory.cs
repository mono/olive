using System.IO;
using System.Reflection;
using System.Text;
using System.Data.Linq.Design.SchemaObjectModel;

namespace System.Data.Linq.Design
{
    public static class DbmlExtractorFactory
    {
        public static IDatabaseExtractor CreateExtractor()
        {
            return new DbmlExtractor();
        }

        #region DbmlExtractor
        private class DbmlExtractor : IDatabaseExtractor
        {
            #region Fields
            private ExtractOptions options;
            private TextWriter logger;
            private string dbName;
            private IDbConnection conn;
            private Database database;
            #endregion

            #region Private Methods
            private void Extract()
            {
            }
            #endregion

            #region Private Static Methods
            private static IDbConnection CreateConnection(string connTypeString, string connString)
            {
                Type connType = Type.GetType(connTypeString, false, true);
                if (connType == null)
                    throw new InvalidOperationException();
                if (!typeof(IDbConnection).IsAssignableFrom(connType))
                    throw new InvalidOperationException();

                // first look for a constructor defining the connection string...
                ConstructorInfo ctor = connType.GetConstructor(new Type[] { typeof(string) });
                if (ctor != null)
                    return (IDbConnection)ctor.Invoke(new object[] { connString });
                
                // ... ok, not found: let's look for the default constructor...
                ctor = connType.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                    throw new InvalidOperationException();

                IDbConnection conn = (IDbConnection)ctor.Invoke(null);
                conn.ConnectionString = connString;

                return conn;
            }
            #endregion

            #region Public Methods

            public void ExtractToFile(string connection, string database, ExtractOptions options, string resultFile)
            {
                string s = ExtractToText(connection, database, options);
                byte[] bytes = Encoding.UTF8.GetBytes(s);

                FileStream stream = new FileStream(resultFile, FileMode.Create, FileAccess.Write, FileShare.None, bytes.Length);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            //[MonoTODO()]
            public string ExtractToText(string connection, string database, ExtractOptions options)
            {
                this.options = options;
                conn = CreateConnection(options.ConnectionTypeString, connection);
                logger = options.Log;
                dbName = database;

                Extract();

                //TODO:

                throw new NotImplementedException();
            }

            #endregion
        }
        #endregion
    }
}