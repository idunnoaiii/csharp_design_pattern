using System.Collections;

namespace CompositeCommand;

public interface ICommand
{
    void Call();
    void Undo();
    bool Success { get; }
}

public class BankAccountCommand : ICommand
{
    private BankAccount _account;
    
    public enum Action
    {
        Deposit, Withdraw
    }

    private Action _action;
    private int _amount;
    private bool succeeded;

    public BankAccountCommand(BankAccount account, Action action, int amount)
    {
        _account = account;
        _action = action;
        _amount = amount;
    }

    public void Call()
    {
        switch (_action)
        {
            case Action.Deposit:
                _account.Deposit(_amount);
                succeeded = true;
                break;
            case Action.Withdraw:
                succeeded = _account.Withdraw(_amount);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Undo()
    {
        if (!succeeded) return;
        switch (_action)
        {
            case Action.Deposit:
                _account.Withdraw(_amount);
                break;
            case Action.Withdraw:
                _account.Deposit(_amount);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public bool Success { get => succeeded; }
}

public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
{
    public CompositeBankAccountCommand()
    {
    }

    public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> collection) : base(collection)
    {
    }

    public virtual void Call()
    {
        ForEach(cmd => cmd.Call());
    }

    public virtual void Undo()
    {
        foreach (var cmd in ((IEnumerable<BankAccountCommand>)this).Reverse())
        {
            if(cmd.Success) cmd.Undo();
        }
    }

    public virtual bool Success
    {
        get
        {
            return this.All(cmd => cmd.Success);
        }
    }
}

public class MoneyTransfer : CompositeBankAccountCommand
{
    public MoneyTransfer(BankAccount from, BankAccount to, int amount)
    {
        AddRange(new []
        {
            new BankAccountCommand(from, BankAccountCommand.Action.Withdraw, amount),
            new BankAccountCommand(to, BankAccountCommand.Action.Deposit, amount)
        });
    }
    
}