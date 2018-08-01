using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string WeeklyPickupDay { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OneTimePickupDate { get; set; }
        //public DateTime OneTimePickupDate { get; set; }
        public string MoneyOwed { get; set; }

        //FK to ApplicationUser
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

