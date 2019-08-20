using System;

namespace BlushMe.Model
{
    public class WorkHour
    {
        public int WorkHourId { get; set; }
        public int LocationId { get; set; }
        public Day Day { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public Location Location { get; set; }
    }
}