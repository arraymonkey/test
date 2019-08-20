namespace BlushMe.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public int LocationId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public virtual Location Location { get; set; }
    }
}