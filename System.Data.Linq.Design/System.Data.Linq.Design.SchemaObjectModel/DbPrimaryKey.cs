using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbPrimaryKey : DbObject
    {
        public List<DbKeyColumn> Columns = new List<DbKeyColumn>();
    }
}