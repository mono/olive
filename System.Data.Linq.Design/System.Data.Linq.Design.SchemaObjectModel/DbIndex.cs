using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbIndex : DbObject
    {
        public List<DbKeyColumn> Columns = new List<DbKeyColumn>();
        public string IsUnique;
        public string Style;
    }
}