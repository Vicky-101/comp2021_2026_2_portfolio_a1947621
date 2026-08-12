BankAccount account = new BankAccount("vicky", 1000m);

Console.WriteLine($"Owner: {account.Owner}");
Console.WriteLine($"Starting balance: ${account.Balance}");

account.Deposit(500m);
Console.WriteLine($"After decimal deposit: ${account.Balance}");

account.Deposit(100);
Console.WriteLine($"After int deposit: ${account.Balance}");

account.Deposit(50.5);
Console.WriteLine($"After double deposit: ${account.Balance}");

account.Withdraw(200m);
Console.WriteLine($"After withdrawing $200: ${account.Balance}");

 