﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Database.Model
 {
    public  class Applicant
    {
        public Guid ApplicantID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
