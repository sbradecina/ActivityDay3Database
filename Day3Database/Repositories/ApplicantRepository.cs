using Day3Database.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day3Database.Repositories
{
    public class ApplicantRepository : RepositoryBase<Applicant>
    {

       protected string insertStatement = @"INSERT INTO[Applicant]
                    (ApplicantID,
                    FirstName,
                    MiddleName,
                    LastName,
                    BirthDate
                    )
                     Values
                     (
                            @applicantID,
                            @firstName,
                            @middleName,
                            @lastName,
                            @birthDate
                     )";
        private readonly string updateStatement = @"Update [Applicant]
                    SET
                    FirstName = @firstName,
                    MiddleName = @middleName,
                    LastName = @lastName,
                    BirthDate= @birthDate
                    WHERE ApplicantId= @applicantID";

        private readonly string retrieveStatement = @"Select ApplicantID,
                    FirstName,
                    MiddleName,
                    LastName,
                    BirthDate
                    FROM [Applicant] ";
        private readonly string retrieveFilter =
                    "WHERE ApplicantID = @applicantID";
        private readonly string deleteStatement = @"Delete from [Applicant]
                    WHERE ApplicantId= @applicantID";

        public ApplicantRepository()
        {
            base.InsertStatement = this.insertStatement;
            base.DeleteStatement = this.deleteStatement;
            base.UpdateStatement = this.updateStatement;
            base.RetrieveStatement = this.retrieveStatement + retrieveFilter;
            base.RetrieveAllStatement = this.retrieveStatement;
        }
        protected override Applicant LoadEntity(SqlDataReader reader)
        {
            var applicant = new Applicant();
            applicant.ApplicantID = reader.GetGuid(0);
            applicant.FirstName = reader.GetString(1);
            applicant.MiddleName = reader.GetString(2);
            applicant.LastName = reader.GetString(3);
            applicant.BirthDate = reader.GetDateTime(4);
            return applicant;
        }

        protected override void LoadRetrieveParameter(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
            .Value = id;
        }


        protected override void LoadInsertParameters(SqlCommand command, Applicant newApplicant)
        {
            command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                        .Value = newApplicant.ApplicantID;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                .Value = newApplicant.FirstName;
            command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50)
               .Value = newApplicant.MiddleName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50)
               .Value = newApplicant.LastName;
            command.Parameters.Add("@birthDate", SqlDbType.DateTime)
               .Value = newApplicant.BirthDate;

            
        }
       
        
        protected override void LoadDeleteParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                       .Value = id;
        }
        protected override void LoadUpdateParameters(SqlCommand command, Applicant applicant)
        {
            command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                        .Value = applicant.ApplicantID;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                .Value = applicant.FirstName;
            command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50)
               .Value = applicant.MiddleName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50)
               .Value = applicant.LastName;
            command.Parameters.Add("@birthDate", SqlDbType.DateTime)
               .Value = applicant.BirthDate;
        }
        
       
        
    }
}
