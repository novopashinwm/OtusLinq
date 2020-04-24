using System;
using System.Linq;
using Otus.Teaching.Linq.ATM.Core.Services;
using Otus.Teaching.Linq.ATM.DataAccess;

namespace Otus.Teaching.Linq.ATM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Старт приложения-банкомата...");

            var atmManager = CreateATMManager();

            atmManager.ShowUserByLoginPass("snow", "111");
            atmManager.ShowUsersAccounts(5);
            atmManager.ShowAllAccountandHistoryUser(5);
            atmManager.ShowAllOperationInAccounts(9);
            atmManager.ShowAllUsersMoreN(100_000);
            System.Console.WriteLine("Завершение работы приложения-банкомата...");
        }

        static ATMManager CreateATMManager()
        {
            using var dataContext = new ATMDataContext();
            var users = dataContext.Users.ToList();
            var accounts = dataContext.Accounts.ToList();
            var history = dataContext.History.ToList();
                
            return new ATMManager(accounts, users, history);
        }
    }
}