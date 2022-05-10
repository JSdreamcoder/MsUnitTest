

abstract class Account  //abstract
{
    public int id;
    public string customerName;
    
}

class SavingAccout : Account  // inheriance
{
    public SavingAccout(int accountid, string name) // can use property from parents class by inherits
    {
        id = accountid;
        customerName = name;
    }
}

class CheckngAccount : Account
{

}


abstract class User  // this  is the example of Abstract.
{
    public int id;
    public string name;
    public string email;
}

class Manager : User
{
    public List<Account> GetAllAcccount()
    {

    }

}

