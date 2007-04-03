using System.Collections.Generic;

namespace System.Data.Linq.Design.SchemaObjectModel
{
    public class DbAssociation : DbObject
    {
        public List<DbKeyColumn> Columns = new List<DbKeyColumn>();
        public string DeleteRule;
        public RelationshipKind Kind;
        public string Property;
        public string Target;
        public string UpdateRule;
    }
}