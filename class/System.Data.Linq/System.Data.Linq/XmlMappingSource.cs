// Permission is hereby granted, free of charge, to any person obtaining
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
using System.Data.Linq.Provider;
using System.IO;
using System.Xml;

namespace System.Data.Linq
{
    /// <summary>
    /// A source that maps against an XML serialization of the
    /// DLINQ Mapping Schema.
    /// </summary>
    public sealed class XmlMappingSource : MappingSource
    {
        #region .ctor
        private XmlMappingSource(XmlDatabaseMapping dbMapping)
        {
            this.dbMapping = dbMapping;
        }
        #endregion

        #region Fields
        private XmlDatabaseMapping dbMapping;
        private Dictionary<Type, MetaModel> models = new Dictionary<Type,MetaModel>();
        #endregion

        #region Private Static Methods
        private static XmlDatabaseMapping ReadDatabaseMapping(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlElement dbElement = doc.DocumentElement;
            if (dbElement.LocalName != "Database")
                throw new InvalidOperationException();

            string name = dbElement.GetAttribute("Name");
            if (name == null)
                throw new InvalidOperationException();

            string providerType = dbElement.GetAttribute("ProviderType");

            XmlDatabaseMapping dbMapping = new XmlDatabaseMapping(name, providerType);

            try
            {
                dbMapping = new XmlDatabaseMapping(name, providerType);

                XmlNodeList childNodes = dbElement.ChildNodes;

                for (int i = 0; i < childNodes.Count; i++)
                {
                    XmlElement child = childNodes[i] as XmlElement;
                    switch (child.LocalName)
                    {
                        case "Table":
                            dbMapping.Tables.Add(ReadTableElement(child));
                            break;
                        case "StoredProcedure":
                            break;
                        case "UserDefinedFunction":
                            break;
                        case "TableValuedFunction":
                            break;
                    }
                }
            }
            catch
            {
                dbMapping = null;
                throw;
            }

            return dbMapping;
        }

        private static XmlTableMapping ReadTableElement(XmlElement element)
        {
            string name = element.GetAttribute("name");
            if (name == null || name.Length == 0)
                throw new InvalidOperationException();

            XmlTableMapping tableMapping = new XmlTableMapping(name);

            XmlNodeList childNodes = element.ChildNodes;
            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlElement child = childNodes[i] as XmlElement;
                if (child.LocalName != "Type") //ISSUE: should we ignore the case?
                    throw new InvalidOperationException();

                if (tableMapping.RowType != null)
                    throw new InvalidOperationException();

                tableMapping.RowType = ReadTypeElement(child);
            }

            return tableMapping;
        }

        private static XmlTypeMapping ReadTypeElement(XmlElement element)
        {
            string name = element.GetAttribute("Name");
            if (name == null || name.Length == 0)
                throw new InvalidOperationException();

            XmlTypeMapping typeMapping = new XmlTypeMapping(name);

            typeMapping.InheritanceCode = element.GetAttribute("InheritanceCode");

            string inheritanceDefault = element.GetAttribute("IsInheritanceDefault");
            if (inheritanceDefault == null)
            {
                typeMapping.IsInheritanceDefault = false;
            }
            else
            {
                try
                {
                    typeMapping.IsInheritanceDefault = Boolean.Parse(inheritanceDefault);
                }
                catch (FormatException)
                {
                    throw new InvalidOperationException();
                }
            }

            XmlNodeList childNodes = element.ChildNodes;
            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlElement child = childNodes[i] as XmlElement;
                switch (child.LocalName)
                {
                    case "Type":
                        typeMapping.Derived.Add(ReadTypeElement(child));
                        break;
                    case "Association":
                        break;
                    case "Column":
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            return typeMapping;
        }
        #endregion

        #region Protected Methods
        protected internal override MetaModel CreateModel(Type contextType)
        {
            if (contextType == null)
                throw new ArgumentNullException("contextType");

            MetaModel model = models[contextType];
            if (model == null)
            {
                //TODO: we have to create it and add it to the dictionary...
            }

            return model;
        }
        #endregion

        #region Public Static Methods
        public static XmlMappingSource FromStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            return FromReader(new XmlTextReader(stream));
        }

        public static XmlMappingSource FromReader(XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            return new XmlMappingSource(ReadDatabaseMapping(reader));
        }

        public static XmlMappingSource FromUrl(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            return FromReader(new XmlTextReader(url));
        }

        public static XmlMappingSource FromXml(string xml)
        {
            if (xml == null)
                throw new ArgumentNullException("xml");

            return FromReader(new XmlTextReader(new StringReader(xml)));
        }
        #endregion
    }
}