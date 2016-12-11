using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulOperation.Entity;

namespace RestfulOperation.Operation
{
    public class EmployeeOperation
    {
         
        public static List<EmployeeEntity> GetEmployees()
        {
            List<EmployeeEntity> empList = new List<EmployeeEntity>();
            try
            {
                
                SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Company; User ID = restfultest; Password = restfultest");

                string sqlSelectString = "SELECT * FROM Employee";
                SqlCommand command = new SqlCommand(sqlSelectString, conn);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeEntity emp = new EmployeeEntity();
                    emp.FirstName = reader[0].ToString();
                    emp.LastName = reader[1].ToString();
                    emp.EmpCode = Convert.ToInt16(reader[2]);
                    emp.Designation = reader[3].ToString();
                    empList.Add(emp);
                }
                command.Connection.Close();
                return empList; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
