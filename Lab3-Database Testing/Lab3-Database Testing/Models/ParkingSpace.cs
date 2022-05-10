namespace Lab3_Database_Testing.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; } 

        public int Number { get; set; }
        public bool Parked { get; set; }
        
        public ICollection<Reservation> Reservations { get; set; }

        public ParkingSpace(int num)
        {
            Number = num;
            Reservations = new HashSet<Reservation>();
        }

        public ParkingSpace()
        {
            
            Reservations = new HashSet<Reservation>();
        }
    }
}
