using System.Collections;
using System.Collections.Generic;

namespace BlushMe.Model
{
    public class Location
    {
        public int LocationId { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<WorkHour> WorkHours { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}