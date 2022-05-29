// See https://aka.ms/new-consolePerformQuery-template for more information

using CompositeCommand;

// var ba = new BankAccount();
//
// var depositCmd = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
// var withDrawCmd = new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 10);
//
// var composite = new CompositeBankAccountCommand(new List<BankAccountCommand>
// {
//     depositCmd,
//     withDrawCmd
// });
// composite.Call();
// Console.WriteLine(ba);
//
// composite.Undo();
// Console.WriteLine(ba);

var from = new BankAccount();
from.Deposit(100);
var to = new BankAccount();

var mtc = new MoneyTransfer(from, to, 1000);
mtc.Call();

Console.WriteLine(from);
Console.WriteLine(to);

mtc.Undo();

Console.WriteLine(from);
Console.WriteLine(to);