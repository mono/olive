using System.Data.Linq.Provider;

namespace System.Data.Linq
{
    public abstract class MappingSource
    {
        #region .ctor
        protected MappingSource()
        {
        }
        #endregion

        #region Protected Methods
        protected internal abstract MetaModel CreateModel(Type contextType);
        #endregion
    }
}
