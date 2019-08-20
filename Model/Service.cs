using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlushMe.Model
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Active { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual Location Locations { get; set; }


    }
}