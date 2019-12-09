using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Model;

namespace ServiceContract
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCategory/{Id}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Category GetCategoryById(int id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllCategories",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        List<Category> GetAllCategories();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            UriTemplate = "/ModifyCategory",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        void ModifyCategory(Category category);
    }
}
