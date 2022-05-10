namespace RepositoryWIthMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public Customer()
        {
            Accounts = new HashSet<Account>();    
        }

    }
}
