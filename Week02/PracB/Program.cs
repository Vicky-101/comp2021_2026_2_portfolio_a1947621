BankAccount account = new BankAccount("vicky", 1000m);

Console.WriteLine($"Owner: {account.Owner}");
Console.WriteLine($"Starting balance: ${account.Balance}");

account.Deposit(500m);
Console.WriteLine($"After depositing $500: ${account.Balance}");

account.Withdraw(200m);
Console.WriteLine($"After withdrawing $200: ${account.Balance}");

 