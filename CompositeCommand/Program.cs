// See https://aka.ms/new-console-template for more information

using CompositeCommand;

var ba = new BankAccount();

var depositCmd = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
var withDrawCmd = new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 10);

var composite = new CompositeBankAccountCommand(new List<BankAccountCommand>
{
    depositCmd,
    withDrawCmd
});
composite.Call();
Console.WriteLine(ba);

composite.Undo();
Console.WriteLine(ba);