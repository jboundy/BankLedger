using System;
using BankLedger.BLL;
using BankLedger.BLL.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.ConsoleInterface
{
    class Program
    {

        static void Main(string[] args)
        {
            var endApp = false;
            IAccountAccess accountManagement = new AccountAccess();
            IBalanceAccess balanceDetails = null;
            Account account = null;
            while (!endApp)
            {
                Console.Write("Please select from the options below" +
                                 Environment.NewLine +
                                 "1: Create Account" +
                                 Environment.NewLine +
                                 "2: Login" +
                                 Environment.NewLine +
                                 "3: Deposit" +
                                 Environment.NewLine +
                                 "4: Withdraw" +
                                 Environment.NewLine +
                                 "5: Check Balance" +
                                 Environment.NewLine +
                                 "6: Recent Transactions" +
                                 Environment.NewLine +
                                 "7: Logout" + Environment.NewLine);

                var answer = Console.ReadLine();
                var username = "";
                var password = "";
                decimal amount = 0;
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Enter username:");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        password = Console.ReadLine();
                        var accountCreated = accountManagement.AccountCreate(username, password);
                        Console.WriteLine(accountCreated ? "Account created!" : "Account already exists!");
                        Console.WriteLine(Environment.NewLine);
                        break;
                    case "2":
                        Console.WriteLine("Please enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Please enter password");
                        password = Console.ReadLine();
                        account = accountManagement.Login(username, password);
                        balanceDetails = new BalanceAccess(username);
                        Console.WriteLine(Environment.NewLine);
                        if (account != null)
                        {
                            Console.WriteLine("Account Logged in!");
                        }
                        else
                        {
                            Console.WriteLine("Unable to login. Please try again");
                        }
                        Console.WriteLine(Environment.NewLine);
                        break;
                    case "3":
                        Console.WriteLine("How much would you like to deposit?");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        var newBalance = balanceDetails.DepositFunds(amount);
                        Console.WriteLine($"Your new balance is ${newBalance}" + Environment.NewLine);
                        break;
                    case "4":
                        Console.WriteLine("How much would you like to withdraw?");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        var withdrawnBalance = balanceDetails.WithdrawFunds(amount);
                        Console.WriteLine($"Your new balance is ${withdrawnBalance}" + Environment.NewLine);
                        break;
                    case "5":
                        var balance = balanceDetails.CurrentBalance(account.Username);
                        Console.WriteLine($"Your current balance is ${balance}" + Environment.NewLine);
                        break;
                    case "6":
                        var transactions = balanceDetails.RetrieveTransactions();
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        Console.WriteLine(Environment.NewLine);
                        break;
                    case "7":
                        endApp = true;
                        Environment.Exit(Environment.ExitCode);
                        break;
                }
            }
        }
    }
}
