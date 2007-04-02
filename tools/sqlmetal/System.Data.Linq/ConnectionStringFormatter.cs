using System.Collections.Generic;

namespace System.Data.Linq
{
    public abstract class ConnectionStringFormatter
    {
        #region .ctor
        static ConnectionStringFormatter()
        {
            formatterTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            formatterTypes.Add("mysql", typeof(MySqlConnectionStringFormatter));
            formatterTypes.Add("sql", typeof(SqlConnectionStringFormatter));
        }
        #endregion

        #region Fields

        private static readonly Dictionary<String, Type> formatterTypes;
        private static Dictionary<String, ConnectionStringFormatter> formatters;

        #endregion

        #region Public Methods

        public abstract string FormatString(string server, string database, string user, string password);

        #endregion

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// If the given <paramref name="connectionType"/> is not supported.
        /// </exception>
        public static ConnectionStringFormatter GetFormatter(string connectionType)
        {
            ConnectionStringFormatter formatter = null;
            if (formatters != null)
                formatter = formatters[connectionType];

            if (formatter == null)
            {
                Type formatterType = formatterTypes[connectionType];
                if (formatterType == null)
                    throw new ArgumentException();

                formatter = (ConnectionStringFormatter)Activator.CreateInstance(formatterType);

                if (formatters == null)
                    formatters = new Dictionary<string, ConnectionStringFormatter>(StringComparer.OrdinalIgnoreCase);

                formatters.Add(connectionType, formatter);
            }

            return formatter;
        }
        #endregion

        #region MySqlConnectionStringFormatter
        class MySqlConnectionStringFormatter : ConnectionStringFormatter
        {
            public override string FormatString(string server, string database, string user, string password)
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
        #endregion

        #region SqlConnectionStringFormatter
        class SqlConnectionStringFormatter : ConnectionStringFormatter
        {
            public override string FormatString(string server, string database, string user, string password)
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
        #endregion
    }
}