using Model;
using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;


namespace ServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetEmployee/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] //faulcontract allows you to customize the error messages
        Employee GetEmployeeById(string id);
    }
}
