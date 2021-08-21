namespace CarRentApi.CustomerManagement
{
    public class CustomerRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int Zip { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }
    }
}
