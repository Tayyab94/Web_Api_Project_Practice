using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<int> Age { get; set; }
    }
}