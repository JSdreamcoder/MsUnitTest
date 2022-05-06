class Program
{ 
static void Main(string[] args)
{
    var account = new Account();
    account.balance = 1000;
    Console.WriteLine(account.balance);
    account.Withdraw(1001);
    Console.WriteLine(account.balance);
}
}

public class Account
{
    private double _balance;
    public double balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
    public double Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new ArgumentException("Error: insufficient funds for withdrawal.");

        }
        else if (amount <= 0 || amount == null)
        {
            throw new ArgumentException("Withdrawals must be greater than $0");
        }
        balance = balance - amount;
        return balance;
    }

    public double Deposit(double amount)
    {
        if (amount <= 0 || amount == null)
        {
            throw new ArgumentException("Deposits must be in amount greater than $0");
        }
        balance += amount;
        return amount;
    }
}

