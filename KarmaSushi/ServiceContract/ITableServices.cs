using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{   [ServiceContract]
    public interface ITableServices
    {


        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
            Method = "POST", UriTemplate = "/InsertTable", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]  
        Table InsertTable(Table table);
    }
}
