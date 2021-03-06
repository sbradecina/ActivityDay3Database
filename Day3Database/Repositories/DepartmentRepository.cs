﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Day3Database.Model;
using System.Data;
namespace Day3Database.Repositories
{
     public class DepartmentRepository :  RepositoryBase<Department>
        
    {

        private readonly string insertStatement = @"INSERT INTO[Department]
                    (DepartmentID,
                    DepartmentName,
                    IsActive
                    )
                     Values
                     (
                            @departmentID,
                            @departmentName,
                            @isActive
                     )";

        private readonly string updateStatement = @"Update [Department]
                    SET
                    DepartmentName = @departmentName,
                    IsActive = @isActive
                    WHERE DepartmentID = @departmentID";

        private readonly string retrieveStatement = @"Select DepartmentID,
                    DepartmentName,
                    IsActive    
                    FROM [Department] ";

        private readonly string retrieveFilter =
                    "WHERE DepartmentID = @departmentID";
        private readonly string deleteStatement = @"Delete from [Department]
                    WHERE DepartmentID= @departmentID";

        public DepartmentRepository()
        {
            base.InsertStatement = this.insertStatement;
            base.DeleteStatement = this.deleteStatement;
            base.UpdateStatement = this.updateStatement;
            base.RetrieveStatement = this.retrieveStatement + retrieveFilter;
            base.RetrieveAllStatement = this.retrieveStatement;

        }
         

        protected override void LoadInsertParameters(SqlCommand command, Department newDepartment)
        {
            command.Parameters.Add("@departmentID", SqlDbType.UniqueIdentifier)
                       .Value = newDepartment.DepartmentID;
            command.Parameters.Add("@departmentName", SqlDbType.NVarChar, 50)
                .Value = newDepartment.DepartmentName;
            command.Parameters.Add("@isActive", SqlDbType.Bit)
               .Value = newDepartment.IsActive;
        }
        
           
        protected override Department LoadEntity(SqlDataReader reader)
        {
            var department = new Department();
            department.DepartmentID = reader.GetGuid(0);
            department.DepartmentName = reader.GetString(1);
            department.IsActive = reader.GetBoolean(2);
            return department;
        }

        protected override void LoadDeleteParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@departmentID", SqlDbType.UniqueIdentifier)
                       .Value = id;
        }

        protected override void LoadUpdateParameters(SqlCommand command, Department department)
        {
            command.Parameters.Add("@departmentID", SqlDbType.UniqueIdentifier)
                        .Value = department.DepartmentID;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                .Value = department.DepartmentName;
            command.Parameters.Add("@isActive", SqlDbType.Bit)
               .Value = department.IsActive;
        }

        protected override void LoadRetrieveParameter(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@departmentID", SqlDbType.UniqueIdentifier)
            .Value = id;
        }
    }
        }
    

