using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{     [ServiceContract]
    public interface IReservationServices
    {

        //[OperationContract]
        //[WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        //        UriTemplate = "/GetReservationByCustomer/{Customer}", BodyStyle = WebMessageBodyStyle.Bare)]
        //[FaultContract(typeof(Error))]
        //Reservation GetByCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST", 
            UriTemplate = "/InsertOrder", 
            BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Reservation InsertReservation(Reservation reservation);


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllReservations/", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] //Fault contract allows you to customize the error messages
        List<Reservation> GetAllReservations();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT",
            UriTemplate = "/UpdateReservation", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Reservation UpdateReservation(Reservation reservation);


        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT",
           UriTemplate = "/DeleteReservation/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Reservation DeleteReservation(Reservation reservation);
    }
}
