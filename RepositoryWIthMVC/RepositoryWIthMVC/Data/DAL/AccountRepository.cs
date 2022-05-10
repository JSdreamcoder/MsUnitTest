using RepositoryWIthMVC.Models;

namespace RepositoryWIthMVC.Data
{
    public class AccountRepository : IRepository<Account>
    {
        public RepositoryWIthMVCContext Context { get; set; }

        public AccountRepository(RepositoryWIthMVCContext context)
        {
            Context = context;
        }

        //Create
        public void Add(Account account)
        {
            Context.Add(account);
        }

        //Read
        public Account Get(int id)
        {
            return Context.Account.First(a => a.Id == id);
        }
        public Account Get(Func<Account, bool> firstFuction)
        {
            return Context.Account.First(firstFuction);
            // context.Account.First(a=> evaluate to bool)
        }
        public ICollection<Account> GetAll()
        {
            return Context.Account.ToList();
        }
        public ICollection<Account> GetList(Func<Account, bool> func)
        {
            return Context.Account.Where(func).ToList();
        }

        //Update
        public void Update(Account a)
        {
            Context.Account.Update(a);
        }

        public void Delete(Account a)
        {
            Context.Account.Remove(a);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
