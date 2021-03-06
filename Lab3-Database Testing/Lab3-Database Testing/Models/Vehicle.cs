namespace Lab3_Database_Testing.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public bool Parked { get; set; }

        public int PassId { get; set; }
        public Pass Pass { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public Vehicle()
        {
            Reservations = new HashSet<Reservation>();
        }
    }
}
