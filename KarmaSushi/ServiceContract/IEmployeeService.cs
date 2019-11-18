﻿using Model;
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
        /// <summary>
        /// The method return the employee searched by Id.
        ///WebGet is use in REST when you have to read something from the database in this case get an employee by Id.
        /// </summary>
        /// <param Name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetEmployee/{Id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Employee GetEmployeeById(string id);

        /// <summary>
        /// TODO Figure out a way to handle the UriTemplate with an object. Probably also need to change WebGet to WebInvoke
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertEmployee", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))] // Fault contract allows you to customize the error messages
        Employee InsertEmployee(Employee employee);
    }
}
