﻿using Day3Database.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day3Database.Repositories
{
    class EmployeeRepository : RepositoryBase<Employee>
    {
        protected string insertStatement =@"INSERT INTO[Employee]
                    (
                    EmployeeID,
                    FirstName,
                    MiddleName,
                    LastName,
                    DepartmentID
                    )
                     Values
                     (
                            @employeeID,
                            @firstName,
                            @middleName,
                            @lastName,
                            @departmentID
                     )";
        private readonly string updateStatement = @"Update [Employee]
                    SET
                    FirstName = @firstName,
                    MiddleName = @middleName,
                    LastName = @lastName,
                    DepartmentID = @departmentID
                    WHERE EmployeeID= @employeeID";
        private readonly string retrieveStatement = @"Select EmployeeID,
                    FirstName,
                    MiddleName,
                    LastName,
                    DEPARTMENT.DepartmentID
                    FROM [Employee]
                    INNER JOIN DEPARTMENT ON EMPLOYEE.DepartmentID = DEPARTMENT.DepartmentID";
        private readonly string retrieveFilter =
                    " WHERE EmployeeID = @employeeID";
        private readonly string deleteStatement = @"Delete from [Employee]
                    WHERE EmployeeID= @employeeID";
        private readonly string allEmployee = @"Select EmployeeID,
                    FirstName,
                    MiddleName,
                    LastName,
                    DEPARTMENT.DepartmentID
                    FROM [Employee]
                    INNER JOIN DEPARTMENT ON EMPLOYEE.DepartmentID = DEPARTMENT.DepartmentID";

        public EmployeeRepository()
        {
            base.InsertStatement = this.insertStatement;
            base.DeleteStatement = this.deleteStatement;
            base.UpdateStatement = this.updateStatement;
            base.RetrieveStatement = this.retrieveStatement + retrieveFilter;
            base.RetrieveAllStatement = this.retrieveStatement;
        }
        protected override void LoadDeleteParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier)
                       .Value = id;
        }

        protected override Employee LoadEntity(SqlDataReader reader)
        {
            var employee = new Employee();
            employee.EmployeeID = reader.GetGuid(0);
            employee.FirstName = reader.GetString(1);
            employee.MiddleName = reader.GetString(2);
            employee.LastName = reader.GetString(3);
            employee.DepartmentID = reader.GetGuid(4);
            
            return employee;
        }

        protected override void LoadInsertParameters(SqlCommand command, Employee newEntity)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier)
                        .Value = newEntity.EmployeeID;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                .Value = newEntity.FirstName;
            command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50)
               .Value = newEntity.MiddleName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50)
               .Value = newEntity.LastName;
            command.Parameters.Add("@departmentID", SqlDbType.UniqueIdentifier)
              .Value = newEntity.DepartmentID;


        }

        protected override void LoadRetrieveParameter(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier)
            .Value = id;
        }

        protected override void LoadUpdateParameters(SqlCommand command, Employee employee)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier)
                        .Value = employee.EmployeeID;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                .Value = employee.FirstName;
            command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50)
               .Value = employee.MiddleName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50)
               .Value = employee.LastName;
            command.Parameters.Add("@departmentID", SqlDbType.UniqueIdentifier)
             .Value = employee.DepartmentID;

        }
    }
}
