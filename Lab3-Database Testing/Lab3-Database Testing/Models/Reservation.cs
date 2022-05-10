namespace Lab3_Database_Testing.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public bool Current { get; set; }

        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
