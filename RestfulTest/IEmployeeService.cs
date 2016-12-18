using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestfulTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        //GET Operation
        [OperationContract]
        [WebGet(UriTemplate = "GetAllEmployee")]
        List<Employee> GetAllEmployee();

        //GET Operation
        [OperationContract]
        [WebGet(UriTemplate = "GetAnEmployee/{empCode}")]
        Employee GetAnEmployee(string empCode);

        //POST operation
        [OperationContract]
        [WebInvoke(Method = "POST",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "AddEmployee")]
        string AddEmployee(Employee emp);

        //PUT Operation 
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateEmployee", 
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        string UpdateEmployee(Employee emp);

        //DELETE Operation 
        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteEmployee/{empCode}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        string DeleteEmployee(string empCode);
    }
}
