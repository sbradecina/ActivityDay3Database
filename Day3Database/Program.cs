using Day3Database.Model;
using Day3Database.Repositories;
using System;
using System.Collections.Generic;

namespace Day3Database
{
    class Program
    {
        

        static void Main(string[] args)
        {

            var accounting = CreateDepartment("Accounting", false);
            var employee = CreateEmployee("Simon","Dayawa", "Bradecina", accounting.DepartmentID);
            DeleteEmployee(new Guid("DD83AF21-CD9B-4FA6-8D1F-E38F30ABED27"));
            var retrieve =  RetrieveEmployee(employee.EmployeeID);
            var allEmployee = RetrieveAllEmployee();
            UpdateEmployee(employee);
            
            //var sales = CreateDepartment("Sales", true);
            //List<Department> departments = RetrieveAllDepartment();

            //for (int i = 0; i < departments.Count; i++)
            //{
            //    departments[i].DepartmentName = i.ToString();
            //  }

            //   RetrieveAllDepartment();
            //   var departmentName = RetrieveAllDepartment();

            // departments.ForEach((a) =>
            //   DeleteDepartment(a.DepartmentID));



            Console.ReadLine();
        }
        //Applicant
        //static void Main(string[] args)
        //{
        //    var simon = CreateApplicant("Simon", "Dayawa", "Bradecina", DateTime.Parse("1998-05-11"));
        //    var nomis = CreateApplicant("nomis", "Dayawa", "Bradecina", DateTime.Parse("1998-05-11"));
        //    var monsi = CreateApplicant("monsi", "Dayawa", "Bradecina", DateTime.Parse("1998-05-11"));
        //    var inoms = CreateApplicant("inoms", "Dayawa", "Bradecina", DateTime.Parse("1998-05-11"));
        //    var applicant = RetrieveApplicant(simon.ApplicantID);

        //    UpdateApplicant(simon);
        //    RetrieveAllApplicant();
        //    var allApplicants = RetrieveAllApplicant();

        //    allApplicants.ForEach((a) =>
        //    DeleteApplicant(a.ApplicantID));
        //    DeleteApplicant(simon.ApplicantID);

        //    Console.ReadLine();
        //}

        private static object RetrieveApplicant(Guid applicantID)
        {
            var repository = new ApplicantRepository();
            return repository.Retrieve(applicantID);
        }

        static List<Applicant> RetrieveAllApplicant()
        {
            var repo = new ApplicantRepository();
            return repo.Retrieve();
        }

        private static void UpdateDepartment (Applicant applicant)
        {
            applicant.FirstName = "Ezekiel";
            var repository = new ApplicantRepository();
            repository.Update(applicant);
        }
        static Applicant CreateApplicant(string firstName, string middleName, string lastName, DateTime birthDate )
        {
            var applicant = new Applicant
            {
                ApplicantID = Guid.NewGuid(),
                FirstName = "Simon",
                MiddleName = "Dayawa",
                LastName = "Bradecina",
                BirthDate = DateTime.Parse("1998-05-11")

                
            };
            var repository = new ApplicantRepository();
            var newApplicant = repository.Create(applicant);
            return newApplicant;
        }
        static void DeleteApplicant(Guid id)
        {
            var repository = new ApplicantRepository();
            repository.Delete(id);
        
        }

        //Department

        private static object RetrieveDepartment(Guid departmentID)
        {
            var repository = new Department();
            return repository.Retrieve(departmentID);
        }

        static List<Department> RetrieveAllDepartment ()
        {
            var repository = new DepartmentRepository();
            return repository.Retrieve();
        }

        public static void UpdateDepartment(Department department)
        {
            department.DepartmentName = "Accounting";
            var repository = new DepartmentRepository();
            repository.Update(department);
        }
        static Department CreateDepartment(string departmentName, bool isActive)
        {
            var department = new Department
            {
                DepartmentID = Guid.NewGuid(),
                DepartmentName = departmentName,
                IsActive = isActive


            };
            
            var repository = new DepartmentRepository();
            var newDepartment = repository.Create(department);
            return newDepartment;
        }
        static void DeleteDepartment(Guid departmentID)
        {
            var repository = new DepartmentRepository();
            repository.Delete(departmentID);

        }

        //Employee

        private static Employee RetrieveEmployee(Guid employeeID)
        {
            var repository = new EmployeeRepository();
            return repository.Retrieve(employeeID);
        }

        static List<Employee> RetrieveAllEmployee()
        {
            var employeeRepository = new EmployeeRepository();
            return employeeRepository.Retrieve();
        }

        public static void UpdateEmployee(Employee employee)
        {
            employee.FirstName = "Lando";
            employee.DepartmentID = new Guid("591DD626-3186-4495-914F-391B3E46CF57");
            var repository = new EmployeeRepository();
            repository.Update(employee);
        }
        static Employee CreateEmployee(string firstName, string middleName, string lastName, Guid departmentID)
        {
            var employee = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DepartmentID = departmentID
                


            };

            var repository = new EmployeeRepository();
            var newEmployee = repository.Create(employee);
            return newEmployee;
        }
        static void DeleteEmployee(Guid employeeID)
        {
            var repository = new EmployeeRepository();
            repository.Delete(employeeID);

        }


    }
}
