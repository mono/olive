using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbRowset : DbObject
    {
        public string Class;
        public List<DbColumn> Columns = new List<DbColumn>();
    }
}