using System.Collections.Generic;
using System.Reflection;

namespace System.Data.Linq.Provider
{
    public abstract class MetaModel
    {
        #region .ctor
        protected MetaModel()
        {
        }
        #endregion

        #region Properties
        public abstract string DatabaseName { get; }

        public abstract Type ProviderType { get; }
        #endregion


        #region Public Methods
        public abstract MetaFunction GetFunction(MethodInfo method);

        public abstract IEnumerable<MetaFunction> GetFunctions();

        public abstract MetaTable GetTable(Type rowType);

        public abstract IEnumerable<MetaTable> GetTables();

        public abstract MetaType GetUnmappedType(Type type);
        #endregion
    }
}