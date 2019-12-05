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
            UriTemplate = "/GetCustomerById/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        Customer GetCustomerById(string id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCustomerByName/{Name}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        Customer GetCustomerByName(string name);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertCustomer", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Customer InsertCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            UriTemplate = "/ModifyCustomer",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        void ModifyCustomer(Customer customer);
    }
}
