using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ServiceContract
{   [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCustomer/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]

        [FaultContract(typeof(Error))]
        Customer GetCustomerById(string id);


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCustomer/{Name}", BodyStyle = WebMessageBodyStyle.Bare)]

        [FaultContract(typeof(Error))]
        Customer GetCustomerByName(string name);
    }
}
