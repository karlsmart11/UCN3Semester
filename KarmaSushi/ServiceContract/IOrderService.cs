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
            UriTemplate = "/GetEmployee/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] //Fault contract allows you to customize the error messages
        Order GetOrderById(string id);
    }
}
