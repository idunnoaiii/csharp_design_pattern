namespace CompositeCommand;

public class BankAccount
{
    private int _balance;
    private int _overdraftLinit = -500;


    public BankAccount(int balance = 0)
    {
        this._balance = balance;
    }
    
    public void Deposit(int amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited ${amount}, balance is now {_balance}");
    }
    
    
    public bool Withdraw(int amount)
    {
        if (_balance - amount >= _overdraftLinit)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrew ${amount}, balance is now {_balance}");
            return true;
        }
        return false;
    }
    
    public override string ToString()
    {
        return $"{nameof(_balance)}: {_balance}";
    }
    
}

