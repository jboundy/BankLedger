using System;
using BankLedger.BLL;
using BankLedger.DataAccess;
using BankLedger.DataAccess.Models;

namespace BankLedger.ConsoleInterface
{
    class Program
    {
        private BalanceAccess account;
        static void Main(string[] args)
        {
           Console.WriteLine("Please select from the options below:" +
                             "1: Create Account" +
                             "2: Login" +
                             "3: Deposit" +
                             "4: Withdraw" +
                             "5: Logout");

           var line = Console.ReadLine();
        }

        private Account Login(string username, string password)
        {
            Acco
        }
    }
}
