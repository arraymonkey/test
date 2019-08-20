using System;
using System.ComponentModel.DataAnnotations;

namespace BlushMe.Model
{
    public class Hours
    {
        [Key]
        public int HoursId { get; set; }
        public int EmployeeId { get; set; }
        public Day Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}