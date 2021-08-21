namespace CarRentApi.CarManagement
{
    public class CarResponseDto
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public CarClass CarClass { get; set; }
    }
}
