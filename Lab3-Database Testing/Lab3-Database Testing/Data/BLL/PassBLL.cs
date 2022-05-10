using Lab3_Database_Testing.Models;

namespace Lab3_Database_Testing.Data.BLL
{
    public class PassBLL
    {
        Irepository<Pass> repo;
        public PassBLL(Irepository<Pass> repository)
        {
            repo = repository;
        }

        public void CreatePass(Pass pass)
        {
            if (pass.Purchaser.Length >= 3 && pass.Purchaser.Length <= 20)
            {
                repo.Create(pass);
            }else
            {
                throw new Exception("Purchaser should be between 3 and 20");
            }

            //repo.Save();
        }
    }
}
