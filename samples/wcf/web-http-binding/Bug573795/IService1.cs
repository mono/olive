using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyLittleService
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate="GetData?value={value}", ResponseFormat=WebMessageFormat.Json)]
        string GetData(int value);

        [OperationContract]
        [WebInvoke(UriTemplate="GetDataUsingDataContract", ResponseFormat=WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.Wrapped)]
        CompositeType GetDataUsingDataContract(CompositeType composite, CompositeType composite2);

        [OperationContract]
        [WebGet(UriTemplate = "GetSampleJson", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        CompositeType GetSampleJson();

        [OperationContract]
        [WebGet(UriTemplate = "GetOutParams", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        CompositeType GetOutParams(out CompositeType c1, out CompositeType c2);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
