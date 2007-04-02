using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbType : DbObject
    {
        public List<DbAssociation> Associations = new List<DbAssociation>();
        public List<DbColumn> Columns = new List<DbColumn>();
        public List<DbType> DerivedTypes = new List<DbType>();
        public string InheritanceCode;
        public string IsInheritanceDefault = "false";
    }
}