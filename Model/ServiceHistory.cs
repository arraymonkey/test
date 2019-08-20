using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlushMe.Model
{
    public class ServiceHistory
    {
        [Key] public int ServiceHistoryId { get; set; }
        public int EmployeeId { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public int Status { get; set; }
    }
}