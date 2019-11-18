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
    public interface IReservationService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetReservation/{Customer}", BodyStyle = WebMessageBodyStyle.Bare)]

        [FaultContract(typeof(Error))]
        Reservation GetByCustomer(Customer customer);
    }
}
