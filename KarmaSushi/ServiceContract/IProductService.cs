﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{ [ServiceContract]
   public interface IProductService
    { 
    [OperationContract]
    [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetProductBtId/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
    [FaultContract(typeof(Error))]
    Product GetProductById(string id);


    [OperationContract]
    [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetProductByName/{Name}", BodyStyle = WebMessageBodyStyle.Bare)]
    [FaultContract(typeof(Error))]
    Product GetProductByName(string name);

    [OperationContract]
    [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetProductByCategory/{Category}", BodyStyle = WebMessageBodyStyle.Bare)]
    [FaultContract(typeof(Error))]
    Product GetProductByCategory(Category category);

     [OperationContract]
    [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetProductByPrice/{Price}", BodyStyle = WebMessageBodyStyle.Bare)]
    [FaultContract(typeof(Error))]
    Product GetProductByPrice(double price);


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetProducts/", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] 
        List<Product> GetAllProducts();


    }

}

