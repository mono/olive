using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyApp.Common
{
    [Serializable]
    //[XmlRoot(Namespace = Globals.OWK_NAMESPACE)]
    public class ServiceResult
    {
        public bool Error { get; set; }
        public List<ResultInfo> ResultInfoList { get; set; }

        public ServiceResult()
        {
            this.ResultInfoList = new List<ResultInfo>();
        }
    }

    [Serializable]
    //[XmlRoot(Namespace = Globals.OWK_NAMESPACE)]
    public class ServiceResult<T> : ServiceResult
    {
        public T Value { get; set; }
    }
}
