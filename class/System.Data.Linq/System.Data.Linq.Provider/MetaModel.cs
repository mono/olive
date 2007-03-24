﻿// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//
// Authors:
//        Antonello Provenzano  <antonello@deveel.com>
//

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