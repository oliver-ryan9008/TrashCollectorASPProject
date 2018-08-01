using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectorProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int ZipCode { get; set; }
        public List<Customer> pickupList = new List<Customer>();
    }
}
