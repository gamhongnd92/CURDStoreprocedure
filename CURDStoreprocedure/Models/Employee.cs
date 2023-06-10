using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CURDStoreprocedure.Models
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }
        public string Pin_Code { get; set; }

        public string Designation { get; set; }
    }
}