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
        public static EmployeeEntity GetAnEmployee(int empCode)
        {
            EmployeeEntity emp = new EmployeeEntity();
            try
            {

                SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Company; User ID = restfultest; Password = restfultest");

                string sqlSelectString = "SELECT * FROM Employee where ID=" + empCode;
                SqlCommand command = new SqlCommand(sqlSelectString, conn);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    emp.FirstName = reader[0].ToString();
                    emp.LastName = reader[1].ToString();
                    emp.EmpCode = Convert.ToInt16(reader[2]);
                    emp.Designation = reader[3].ToString();

                }
                command.Connection.Close();
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string AddEmployee(EmployeeEntity emp)
        {
            string sqlInserString =
                   "INSERT INTO Employee (FirstName, LastName, ID, Designation) VALUES (@firstName, @lastName, @ID, @designation)";

            SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Company; User ID = restfultest; Password = restfultest");


            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.Connection.Open();
            command.CommandText = sqlInserString;

            SqlParameter firstNameparam = new SqlParameter("@firstName", emp.FirstName);
            SqlParameter lastNameparam = new SqlParameter("@lastName", emp.LastName);
            SqlParameter IDparam = new SqlParameter("@ID", emp.EmpCode);
            SqlParameter designationParam = new SqlParameter("@designation", emp.Designation);

            command.Parameters.AddRange(new SqlParameter[] { firstNameparam, lastNameparam, IDparam, designationParam });
            command.ExecuteNonQuery();
            command.Connection.Close();
            return "ok";
        }

        public static string UpdateEmployee(EmployeeEntity emp)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Company; User ID = restfultest; Password = restfultest");

                string sqlUpdateString =
                    "UPDATE Employee SET FirstName=@firstName, LastName=@LastName, Designation=@Designation WHERE ID=@ID ";



                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Connection.Open();
                command.CommandText = sqlUpdateString;

                SqlParameter firstNameparam = new SqlParameter("@firstName", emp.FirstName);
                SqlParameter lastNameparam = new SqlParameter("@lastName", emp.LastName);
                SqlParameter IDparam = new SqlParameter("@ID", emp.EmpCode);
                SqlParameter designationParam = new SqlParameter("@designation", emp.Designation);

                command.Parameters.AddRange(new SqlParameter[] { firstNameparam, lastNameparam, IDparam, designationParam });
                command.ExecuteNonQuery();
                command.Connection.Close();
                return "ok";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

            }
        }


        public static string DeleteEmployee(int empCode)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Company; User ID = restfultest; Password = restfultest");

                string sqlDeleteString =
                    "DELETE FROM Employee WHERE ID=@empCode ";


                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Connection.Open();
                command.CommandText = sqlDeleteString;

                SqlParameter IDparam = new SqlParameter("@empCode", empCode);
                command.Parameters.Add(IDparam);
                command.ExecuteNonQuery();
                command.Connection.Close();
                return "ok";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}
