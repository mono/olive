using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyApp.Common
{
    [Serializable]
    //[XmlRoot(Namespace = Globals.OWK_NAMESPACE)]
    public class ResultInfo
    {
        public string Message { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public string Component { get; set; }
        public string Module { get; set; }
        public MessageType Type { get; set; }
        public string[] DetailMessages { get; set; }
        public List<ResultInfo> InnerResults { get; set; }

        public ResultInfo()
        {
            this.InnerResults = new List<ResultInfo>();
        }
    }
}
