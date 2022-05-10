using Lab3_Database_Testing.Models;

namespace Lab3_Database_Testing.Data
{
    public class ParkingSpaceRepository : Irepository<ParkingSpace>
    {
        public Lab3_Database_TestingContext db { get; set; }
        public ParkingSpaceRepository(Lab3_Database_TestingContext con)
        {
            db = con;
        }

        public void Create(ParkingSpace parkingspace)
        {
            db.Add(parkingspace);
            
        }

        public ParkingSpace Get(int id)
        {
            return db.ParkingSpace.First(p=>p.Id == id);
        }

        public ParkingSpace Get(Func<ParkingSpace, bool> firstFunction)
        {
            return db.ParkingSpace.First(firstFunction);
        }

        public ICollection<ParkingSpace> GetAll()
        {
            return db.ParkingSpace.ToList();
        }

        public ICollection<ParkingSpace> GetList(Func<ParkingSpace, bool> func)
        {
            return db.ParkingSpace.Where(func).ToList();
        }

        public void Update(ParkingSpace pass)
        {
            db.ParkingSpace.Update(pass);
        }

        public void Delete(ParkingSpace pass)
        {
            db.ParkingSpace.Remove(pass);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
