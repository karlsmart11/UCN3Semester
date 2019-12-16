using Model;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceContract
{
    [ServiceContract]
    public interface IProductServices
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/GetProductById/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        Product GetProductById(string id);


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetProductByName/{Name}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        Product GetProductByName(string name);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetProducts/", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        List<Product> GetAllProducts();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            UriTemplate = "/ModifyProduct",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        void ModifyProduct(Product product);
    }

}

