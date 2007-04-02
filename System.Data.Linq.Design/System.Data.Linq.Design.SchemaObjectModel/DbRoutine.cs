using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbRoutine : DbObject
    {
        public string MethodName;
        public List<DbParameter> Parameters = new List<DbParameter>();
        public int ResultSetsReturned;
        public List<DbRowset> ResultShapes = new List<DbRowset>();
        public bool SchemaErrors;
    }
}