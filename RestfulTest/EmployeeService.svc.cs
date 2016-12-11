﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RestfulOperation.Operation;
using RestfulOperation.Entity;

namespace RestfulTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        //GET Operation 
        public List<Employee> GetAllEmployee()
        {
            try
            {

                List<EmployeeEntity> ent = EmployeeOperation.GetEmployees();
                List<Employee> empList = new List<Employee>();
                for (int i = 0; i < ent.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.FirstName = ent[i].FirstName;
                    emp.LastName = ent[i].LastName;
                    emp.EmpCode = ent[i].EmpCode;
                    emp.Designation = ent[i].Designation;
                    empList.Add(emp);

                }
                return empList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
