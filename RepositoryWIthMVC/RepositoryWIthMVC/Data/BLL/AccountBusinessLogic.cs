using RepositoryWIthMVC.Models;

namespace RepositoryWIthMVC.Data.BLL
{
    public class AccountBusinessLogic
    {
        IRepository<Account> repo;

        public AccountBusinessLogic(IRepository<Account> repository)
        {
            repo = repository;
        }

        
        public List<Account> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public double GetBalance(int id)
        {
            Account account = repo.Get(id);

            if (account == null)
            {
                throw new Exception("Account not found");
            }else
            {
                return account.Balance;
            }
        }

        public void SetAccountToInactive(int id)
        {
            Account account = repo.Get(id);

            if (account == null)
            {
                throw new Exception("Account not found");
            }
            else if(!account.IsActive)
            {
                throw new Exception("Account is already inactive");
            }
            else
            {
                account.IsActive = false;
                repo.Save();
            }
        }
    }
}
