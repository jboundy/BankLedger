using System;
using System.Linq;
using BankLedger.BLL;
using BankLedger.BLL.Interfaces;

namespace BankLedger.ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var endApp = false;
            IAccountAccess accountManagement = new AccountAccess();
            while (!endApp)
            {
                Console.Write("Please select from the options below" +
                                 Environment.NewLine +
                                 "1: Create Account" +
                                 Environment.NewLine +
                                 "2: Login" +
                                 Environment.NewLine +
                                 "3: Exit" + Environment.NewLine);
                var username = "";
                var password = "";
                switch (Console.ReadLine())
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
                        var activeAccount = accountManagement.Login(username, password);
                        if (!string.IsNullOrEmpty(activeAccount.Username))
                        {
                            IBalanceAccess balanceDetails = new BalanceAccess(activeAccount);
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("Account Logged in!");
                            var canLogin = true;
                            while (canLogin)
                            {
                                Console.WriteLine("What would you like to do?" +
                                                  Environment.NewLine +
                                                  "1: Deposit" +
                                                  Environment.NewLine +
                                                  "2: Withdraw" +
                                                  Environment.NewLine +
                                                  "3: Check Balance" +
                                                  Environment.NewLine +
                                                  "4: Recent Transactions" +
                                                  Environment.NewLine +
                                                  "5: Logout" + Environment.NewLine);

                                decimal amount = 0;
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.WriteLine("How much would you like to deposit?");
                                        amount = Convert.ToDecimal(Console.ReadLine());
                                        var newBalance = balanceDetails.DepositFunds(amount);
                                        Console.WriteLine($"Your new balance is ${newBalance}" + Environment.NewLine);
                                        break;
                                    case "2":
                                        Console.WriteLine("How much would you like to withdraw?");
                                        amount = Convert.ToDecimal(Console.ReadLine());
                                        var withdrawnBalance = balanceDetails.WithdrawFunds(amount);
                                        Console.WriteLine($"Your new balance is ${withdrawnBalance}" + Environment.NewLine);
                                        break;
                                    case "3":
                                        var balance = balanceDetails.CurrentBalance(username);
                                        Console.WriteLine($"Your current balance is ${balance}" + Environment.NewLine);
                                        break;
                                    case "4":
                                        var transactions = balanceDetails.RetrieveTransactions();
                                        if (transactions.Any())
                                        {
                                            foreach (var transaction in transactions)
                                            {
                                                Console.WriteLine(transaction);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No transactions have been made");
                                        }
                                        Console.WriteLine(Environment.NewLine);
                                        break;
                                    case "5":
                                        canLogin = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unable to login. Please try again");
                        }
                        Console.WriteLine(Environment.NewLine);
                        break;
                    default:
                        endApp = true;
                        Environment.Exit(Environment.ExitCode);
                        break;

                }
            }
        }
    }
}
