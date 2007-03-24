using System.Collections.Generic;

namespace System.Data.Linq
{
    public struct Link<T>
    {
        #region .ctor
        public Link(T value)
        {
            this.value = value;
            source = null;
        }

        internal Link(IEnumerable<T> source)
        {
            this.source = source;
            this.value = default(T);
        }

        internal Link(Link<T> link)
        {
            value = link.value;
            source = link.source;
        }
        #endregion

        #region Fields
        private T value;
        private IEnumerable<T> source;
        #endregion

        #region Properties
        //TODO:
        public bool HasValue
        {
            get { return true; }
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        internal bool HasLoadedValue
        {
            get { return false; }
        }

        internal bool HasAssignedValue
        {
            get { return false; }
        }

        internal T UnderlyingValue
        {
            get { return value; }
        }

        internal IEnumerable<T> Source
        {
            get { return source; }
        }

        //TODO:
        internal bool HasSource
        {
            get { return false; }
        }
        #endregion
    }
}