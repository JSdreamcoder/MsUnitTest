using System;
namespace MittAccount
{
	//this is a abstract that combines common property and function 
	abstract class Account
    {
        // this is a encapsulation : Id, Type, customerId, Balance, CreateAccount() is bind by Account class
        //Id, customerId,Balance is prevented from using outside of this field(MittAccount) by using private access modifiyer
	    private int Id { get; set; }
	    public string Type { get; set; }
	    private int customerId { get; set; }
	    double Balance { get; set; }
        private int AccountNumber = 1;
	    public virtual void ShowAccountInformation()
        {
	    	Console.WriteLine("Account")
        }
    }

    public class SavingAccount : Account   // This is inheritance : SavingAccount inherits Account
    {
    	// SavingAccount can use Account's proeprty by inherits without any declare
    	public SavingAccount(int id, int customerid, double balance)
        {
    		Id = id;
    		Type = "Saving";
    		customerId = customerid;
    		Balance = balance;
            AccountNumber++;
        }
    	// this is a polymorphism : can use the same function name but result is different from others
    	public override SavingAccount ShowAccountInformation()
        {
            
            Console.WriteLine("Saving Account")
            
        }
    }

    public class CheckingAccount : Account
    {
    	public CheckingAccount(int id, int customerid, double balance)
    	{
    		Id = id;
    		Type = "Checking";
    		customerId = customerid;
    		Balance = balance;
            AccountNumber++;
        }
    
    	public override CheckingAccount ShowAccountInformation()
    	{
    		Console.WriteLine("Checking Account")
            
        }
    }
}

namespace MittUser
{
    
    abstract class User
    {
        public int Id { get; set; }
        private string Name { get; set; }
        public 
    }

    public class Customer : User
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
    }

    public class Manager : User
    {
        public Manager(int id, string name)
        {
            Id = id;
            Name = name;
        }
        private List<Account> GetlAccount(int customerId)
        {
            
        }
    }

    public class Admin : User
    {
        List<MittAccount.CheckingAccount> allCheckingAccount = new List<MittAccount.CheckingAccount>.CheckingAccount>;
        List<MittAccount.SavingAccount> allSavingAccount = new List<MittAccount.SavingAccount>.CheckingAccount>;
        public Admin(int id, string name)
        {
            Id = id;
            Name = name;
        }
        private Account CreateSavingAccount(int id ,int customerid,double balance)
        {
            var newAccount = new MittAccount.SavingAccount(id,customerid,balance)
            allSavingAccount.Add(newAccount);
        }
        private Account CreateCheckingAccount(int id, int customerid, double balance)
        {
            var newAccount = new MittAccount.CheckingAccount(id, customerid, balance)
            allSavingAccount.Add(newAccount);
        }
    }
}