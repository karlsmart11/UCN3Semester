using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface IProductService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetProduct/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]

        [FaultContract(typeof(Error))]
        Product GetProductById(string id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetProduct/{Price}", BodyStyle = WebMessageBodyStyle.Bare)]

        [FaultContract(typeof(Error))]
        Product GetProductByPrice(double price);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetProduct/{Price}", BodyStyle = WebMessageBodyStyle.Bare)]

        [FaultContract(typeof(Error))]
        Product GetProductByCategory(Category category);
    }
}
