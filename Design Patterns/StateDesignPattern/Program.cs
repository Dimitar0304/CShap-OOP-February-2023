

using StateDesignPattern.Models;

Account account = new Account("Dimitar");

account.Deposit(500.0);
account.Deposit(500.0);

account.PayInterests();

account.WithDraw(230.0);
account.WithDraw(270.0);