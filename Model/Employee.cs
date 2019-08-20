using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BlushMe.Model
{
    public  class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobileProvider { get; set; }
        public string ServeId { get; set; }
        public virtual ICollection<Hours> Hours { get; set; }
        public virtual ICollection<ServiceHistory> ServiceHistory { get; set; }
    }
}