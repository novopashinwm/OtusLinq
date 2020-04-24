using System.Collections.Generic;
using Otus.Teaching.Linq.ATM.Core.Entities;
using System;
using System.Linq;
namespace Otus.Teaching.Linq.ATM.Core.Services
{
    public class ATMManager
    {
        public IEnumerable<Account> Accounts { get; private set; }
        
        public IEnumerable<User> Users { get; private set; }
        
        public IEnumerable<OperationsHistory> History { get; private set; }
        
        public ATMManager(IEnumerable<Account> accounts, IEnumerable<User> users, IEnumerable<OperationsHistory> history)
        {
            Accounts = accounts;
            Users = users;
            History = history;
        }

        //1. Show info by login and password.
        public void ShowUserByLoginPass(string login, string pass)
        {
            Console.WriteLine("1. ShowUserByLoginPass");
            Console.WriteLine();
            Console.WriteLine(GetUserReport(GetUserInfoByLoginPass(login, pass)));
            Console.WriteLine();
        }
        public string GetUserReport(User u) 
        {
            return $"Id={u.Id}, {u.SurName} {u.FirstName} {u.MiddleName} " +
                $" passport ={u.PassportSeriesAndNumber}," +
                $" regdate={u.RegistrationDate}, phone= {u.Phone}, l={u.Login}, p={u.Password}";
        }
        public string GetAccountReport(Account a) { 
            return $"Id={a.Id}, OperationDate={a.OpeningDate}," +
                    $"UserId= {a.UserId}, CashAll={a.CashAll}";
        }

        public User GetUserInfoByLoginPass(string login, string pass)
        {
            return Users.Where(u => u.Login == login && u.Password == pass).First();
        }

        //2. Show all accounts user.
        public void ShowUsersAccounts(int ID_USER)
        {
            Console.WriteLine("ShowUserAccounts");
            Console.WriteLine();
            var accounts = GetAccountsByUser(ID_USER);
            foreach (var a in accounts)
            {
                Console.WriteLine(GetAccountReport(a));
            }
            Console.WriteLine();
        }

        public List<Account> GetAccountsByUser(int UserId)
        {
            return Accounts.Where(a => a.UserId == UserId).ToList();
        }

        public string GetOperationReport(OperationsHistory o) 
        {
            return $"Id={o.Id}, AccountId={o.AccountId}, CashSum={o.CashSum}, " +
                $"OperationDate={o.OperationDate}, Type={o.OperationType}";
        }

        //3. Showl all user accounts and there's history.
        public void ShowAllAccountandHistoryUser(int ID_USER)
        {
            Console.WriteLine("showAllAccountandHistoryUser");
            Console.WriteLine();
            var arrAcc = GetAccountsByUser(ID_USER);
            foreach (var account in arrAcc)
            {
                Console.WriteLine(GetAccountReport(account));
                Console.WriteLine();
                Console.WriteLine("Show operations:");
                var operations = GetOperationByAccount(account.Id);
                foreach (var operation in operations)
                {
                    Console.WriteLine(GetOperationReport( operation));
                }
            }
            Console.WriteLine();
        }

        public List<OperationsHistory> GetOperationByAccount(int AccountId)
        {
            return History.Where(o => o.AccountId == AccountId).ToList();
        }

        //4. Show all Cash-in operation account. 
        public void ShowAllOperationInAccounts(int AccountId)
        {
            Console.WriteLine("showAllOperationInAccounts");
            Console.WriteLine();
            Console.WriteLine(GetUserReport(Users.Where(u=> u.Id==Accounts.Where(a=>
            a.Id==AccountId).First().UserId ).First()));
            foreach (var item in GetAllOperationsInCash(AccountId))
            {
                Console.WriteLine(GetOperationReport(item));
            }
            Console.WriteLine();
        }

        public List<OperationsHistory> GetAllOperationsInCash(int AccountID)
        {
            return History.Where(h => h.AccountId == AccountID 
            && h.OperationType == OperationType.InputCash).ToList();
        }

        //5. Show all user what CashSum more than N.
        public void ShowAllUsersMoreN(decimal N) 
        {
            Console.WriteLine("ShowAllUsersMoreN");
            Console.WriteLine($"N={N}");
            Console.WriteLine();
            foreach (var user in Users) 
            {
                try
                {
                    if (Accounts.Where(a => a.CashAll > N && a.UserId == user.Id).First() != null)
                    {
                        Console.WriteLine(GetUserReport(user));
                    }
                }
                catch { }
            }

            Console.WriteLine();
        }


    }
}