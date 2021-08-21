namespace CarRentApi.CarManagement
{
    public class CarRequestDto
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public virtual int CarClassId { get; set; }
    }
}
