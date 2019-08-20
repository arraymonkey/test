using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlushMe.Model
{
    public class Client
    {
        [Key]
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long? Points { get; set; }
        public int? Status { get; set; }
        public int? Membership { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}