using Lab3_Database_Testing.Models;

namespace Lab3_Database_Testing.Data.BLL
{
    public class ParkingBLL
    {
        Irepository<ParkingSpace> repo;
        public ParkingBLL(Irepository<ParkingSpace> r)
        {
            repo = r;
        }

        public void CreateParkingSpace(ParkingSpace p)
        {
            if (p.Number < 1)
            {
                throw new Exception("Number should be more than 0");
            }else
            {
                repo.Create(p);
            }
        }
    }
}
