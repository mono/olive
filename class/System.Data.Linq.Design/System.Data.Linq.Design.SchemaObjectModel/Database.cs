using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class Database : DbElement
    {
        public string Class;
        public List<DbSchema> Schemas = new List<DbSchema>();
    }
}