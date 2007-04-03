using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbSchema : DbElement
    {
        public string Class;
        public List<DbFunction> Functions = new List<DbFunction>();
        public string Property;
        public List<DbStoredProcedure> StoreProcedures = new List<DbStoredProcedure>();
        public List<DbTable> Tables = new List<DbTable>();
        public List<DbView> Views = new List<DbView>();
    }
}