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
    }
}
