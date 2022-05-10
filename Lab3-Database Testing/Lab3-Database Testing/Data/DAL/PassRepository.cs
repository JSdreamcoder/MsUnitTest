using Lab3_Database_Testing.Models;

namespace Lab3_Database_Testing.Data
{
    public class PassRepository : Irepository<Pass>
    {
        public Lab3_Database_TestingContext db { get; set; }
        public PassRepository(Lab3_Database_TestingContext con)
        {
            db = con;
        }

        public void Create(Pass pass)
        {
            db.Add(pass);
        }

        public Pass Get(int id)
        {
            return db.Pass.First(p => p.Id == id);
        }

        public Pass Get(Func<Pass, bool> firstFunction)
        {
            return db.Pass.First(firstFunction);
        }

        public ICollection<Pass> GetAll()
        {
            return db.Pass.ToList();
        }

        public ICollection<Pass> GetList(Func<Pass, bool> func)
        {
            return db.Pass.Where(func).ToList();
        }

        public void Update(Pass pass)
        {
            db.Pass.Update(pass);
        }

        public void Delete(Pass pass)
        {
            db.Pass.Remove(pass);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
