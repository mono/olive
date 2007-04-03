using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbTable : DbObject
    {
        public List<DbAssociation> Associations = new List<DbAssociation>();
        public string Class;
        public List<DbColumn> Columns = new List<DbColumn>();
        public List<DbIndex> Indexes = new List<DbIndex>();
        public DbPrimaryKey PrimaryKey;
        public string Property;
        public DbType Type;
    }
}