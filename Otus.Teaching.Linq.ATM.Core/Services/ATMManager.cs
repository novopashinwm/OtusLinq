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

        //1. Вывод информации о заданном аккаунте по логину и паролю;
        public void ShowUserByLoginPass(string login, string pass)
        {
            Console.WriteLine("1. ShowUserByLoginPass");
            Console.WriteLine();
            Console.WriteLine(getUserReport(getUserInfoByLoginPass(login, pass)));
            Console.WriteLine();
        }
        public string getUserReport(User u) 
        {
            return $"Id={u.Id}, {u.SurName} {u.FirstName} {u.MiddleName} " +
                $" passport ={u.PassportSeriesAndNumber}," +
                $" regdate={u.RegistrationDate}, phone= {u.Phone}, l={u.Login}, p={u.Password}";
        }
        public string getAccountReport(Account a) { 
            return $"Id={a.Id}, OperationDate={a.OpeningDate}," +
                    $"UserId= {a.UserId}, CashAll={a.CashAll}";
        }

        public User getUserInfoByLoginPass(string login, string pass)
        {
            return Users.Where(u => u.Login == login && u.Password == pass).First();
        }

        //2. Вывод данных о всех счетах заданного пользователя;
        public void showUsersAccounts(int ID_USER)
        {
            Console.WriteLine("ShowUserAccounts");
            Console.WriteLine();
            var accounts = getAccountsByUser(ID_USER);
            foreach (var a in accounts)
            {
                Console.WriteLine(getAccountReport(a));
            }
            Console.WriteLine();
        }

        public List<Account> getAccountsByUser(int UserId)
        {
            return Accounts.Where(a => a.UserId == UserId).ToList();
        }

        public string getOperationReport(OperationsHistory o) 
        {
            return $"Id={o.Id}, AccountId={o.AccountId}, CashSum={o.CashSum}, " +
                $"OperationDate={o.OperationDate}, Type={o.OperationType}";
        }

        //3. Вывод данных о всех счетах заданного пользователя, включая историю по каждому счёту;
        public void showAllAccountandHistoryUser(int ID_USER)
        {
            Console.WriteLine("showAllAccountandHistoryUser");
            Console.WriteLine();
            var arrAcc = getAccountsByUser(ID_USER);
            foreach (var account in arrAcc)
            {
                Console.WriteLine(getAccountReport(account));
                Console.WriteLine();
                Console.WriteLine("Show operations:");
                var operations = getOperationByAccount(account.Id);
                foreach (var operation in operations)
                {
                    Console.WriteLine(getOperationReport( operation));
                }
            }
            Console.WriteLine();
        }

        public List<OperationsHistory> getOperationByAccount(int AccountId)
        {
            return History.Where(o => o.AccountId == AccountId).ToList();
        }

        //4. Вывод данных о всех операциях пополнения счёта с указанием владельца каждого счёта; 
        public void showAllOperationInAccounts(int AccountId)
        {
            Console.WriteLine("showAllOperationInAccounts");
            Console.WriteLine();
            Console.WriteLine(getUserReport(Users.Where(u=> u.Id==Accounts.Where(a=>a.Id==AccountId).First().UserId ).First()));
            foreach (var item in getAllOperationsInCash(AccountId))
            {
                Console.WriteLine(getOperationReport(item));
            }
            Console.WriteLine();
        }

        public List<OperationsHistory> getAllOperationsInCash(int AccountID)
        {
            return History.Where(h => h.AccountId == AccountID 
            && h.OperationType == OperationType.InputCash).ToList();
        }

        //5. Вывод данных о всех пользователях у которых на счёте сумма больше N
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
                        Console.WriteLine(getUserReport(user));
                    }
                }
                catch { }
            }

            Console.WriteLine();
        }


    }
}