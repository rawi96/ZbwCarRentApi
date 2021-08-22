using CarRentApi.CarManagement;
using CarRentApi.CustomerManagement;
using System;

namespace CarRentApi.ReservationManagement
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual int CarId { get; set; }
        public virtual Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsContract { get; set; }
    }
}
