using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLittleService
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite, CompositeType composite2)
        {
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region IService1 Members
        
        
        public CompositeType GetSampleJson()
        {
            CompositeType ct = new CompositeType();
            ct.BoolValue = true;
            ct.StringValue = "Hello World";
            return ct;

        }

        public CompositeType GetOutParams(out CompositeType c1, out CompositeType c2)
        {
            c1 = new CompositeType();
            c1.BoolValue = true;
            c1.StringValue = "aaa";

            c2 = new CompositeType();
            c2.BoolValue = true;
            c2.StringValue = "bbb";

            return c2;
        }

        #endregion
    }
}
