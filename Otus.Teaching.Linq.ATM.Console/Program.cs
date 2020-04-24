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

            //TODO: Далее выводим результаты разработанных LINQ запросов
            atmManager.ShowUserByLoginPass("snow", "111");
            atmManager.showUsersAccounts(5);
            atmManager.showAllAccountandHistoryUser(5);
            atmManager.showAllOperationInAccounts(9);
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