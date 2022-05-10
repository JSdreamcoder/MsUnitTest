namespace Lab3_Database_Testing.Models
{
    public class Pass
    {
        public int Id { get; set; } 

        public string Purchaser { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

        public Pass(string purchaser)
        {
            Purchaser = purchaser;
            Vehicles = new HashSet<Vehicle>();
        }
    }
}
