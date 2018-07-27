using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectorProject.Models
{
    
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public DateTime PickupDate { get; set; }
        public double Wallet { get; set; }
    }
}