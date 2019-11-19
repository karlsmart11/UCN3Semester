using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ServiceContract
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetOrder/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] //Fault contract allows you to customize the error messages
        Order GetOrderById(string id);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertOrder", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Order InsertOrder(Order order);
    }
}
