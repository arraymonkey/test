using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlushMe.Model
{
    public class Category
    {
 
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}