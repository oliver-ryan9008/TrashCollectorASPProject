using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectorProject.Models
{
    public class PickupDate
    {
        [Key]
        public int CustomerId { get; set; }
        public DateTime PickupDates { get; set; }
    }
}