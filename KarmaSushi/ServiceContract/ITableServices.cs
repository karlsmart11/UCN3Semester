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

        //TODO Fix me
        //[OperationContract]
        //[WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "/GetTablesByOrder/", BodyStyle = WebMessageBodyStyle.Bare)]
        //[FaultContract(typeof(Error))] //Fault contract allows you to customize the error messages
        //List<Table> GetTablesByOrder(Order order);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllTables/", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] //Fault contract allows you to customize the error messages
        List<Table> GetAllTables();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetTablesBySeats/", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] //Fault contract allows you to customize the error messages
        List<Table> GetTablesBySeats(int seats);
    }
}
