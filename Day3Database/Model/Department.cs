using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Database.Model
{
     public class Department
    {
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }



        internal object Retrieve(Guid departmentID)
        {
            throw new NotImplementedException();
        }
    }
}
