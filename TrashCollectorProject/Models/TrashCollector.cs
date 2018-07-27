using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectorProject.Models
{
    
    public class TrashCollector
    {
        [Key]
        public string EmailAddress { get; set; }
    }
}