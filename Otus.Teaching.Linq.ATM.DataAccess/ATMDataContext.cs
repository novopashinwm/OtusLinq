﻿using System;
using System.Collections.Generic;
using System.Linq;
using Otus.Teaching.Linq.ATM.Core.Entities;

namespace Otus.Teaching.Linq.ATM.DataAccess
{
    public class ATMDataContext
        : IDisposable
    {
        public IQueryable<User> Users =>
            new List<User>()
            {
                new User{Id = 1, SurName = "Snow", FirstName = "Mike", MiddleName = "Bob", Phone = "111111", PassportSeriesAndNumber = "6666 123421", RegistrationDate = DateTime.Now.AddMonths(-12), Login = "snow", Password = "111" },
                new User{Id = 2, SurName = "Lee", FirstName = "Ann", MiddleName = "Mike", Phone = "222222", PassportSeriesAndNumber = "7777 123123", RegistrationDate = DateTime.Now.AddMonths(-22), Login = "lee", Password = "222" },
                new User{Id = 3, SurName = "Cant", FirstName = "Greg", MiddleName = "Tor", Phone = "333333", PassportSeriesAndNumber = "8888213124", RegistrationDate = DateTime.Now.AddMonths(-42), Login = "cant", Password = "333" },
                new User{Id = 4, SurName = "Star", FirstName = "Jonh", MiddleName = "Ctor", Phone = "444444", PassportSeriesAndNumber = "9999123123", RegistrationDate = DateTime.Now.AddMonths(-15), Login = "star", Password = "444" },
                new User{Id = 5, SurName = "Cop", FirstName = "Mike", MiddleName = "Prop", Phone = "555555", PassportSeriesAndNumber = "2133321414", RegistrationDate = DateTime.Now.AddMonths(-32), Login = "cop", Password = "555" }
            }.AsQueryable();

        public IQueryable<Account> Accounts =>
            new List<Account>()
            {
                new Account{Id = 1, OpeningDate = DateTime.Now.AddMonths(-12), CashAll = 100500m, UserId = 1 },
                new Account{Id = 2, OpeningDate = DateTime.Now.AddMonths(-10), CashAll = 500m, UserId = 1 },
                new Account{Id = 3, OpeningDate = DateTime.Now.AddMonths(-2), CashAll = 100m, UserId = 1 },
                new Account{Id = 4, OpeningDate = DateTime.Now.AddMonths(-22), CashAll = 10000m, UserId = 2 },
                new Account{Id = 5, OpeningDate = DateTime.Now.AddMonths(-12), CashAll = 5000m, UserId = 2 },
                new Account{Id = 6, OpeningDate = DateTime.Now.AddMonths(-42), CashAll = 10500m, UserId = 3 },
                new Account{Id = 7, OpeningDate = DateTime.Now.AddMonths(-15), CashAll = 1500m, UserId = 4 },
                new Account{Id = 8, OpeningDate = DateTime.Now.AddMonths(-32), CashAll = 10000m, UserId = 5 },
                new Account{Id = 9, OpeningDate = DateTime.Now.AddMonths(-3), CashAll = 100550m, UserId = 5 }
            }.AsQueryable();

        public IQueryable<OperationsHistory> History =>
            new List<OperationsHistory>()
            {
                new OperationsHistory{Id = 1, OperationDate = DateTime.Now.AddDays(-30), OperationType = OperationType.InputCash, CashSum = 100m, AccountId = 1 },
                new OperationsHistory{Id = 2, OperationDate = DateTime.Now.AddDays(-20), OperationType = OperationType.OutputCash, CashSum = 50m, AccountId = 1 },
                new OperationsHistory{Id = 3, OperationDate = DateTime.Now.AddDays(-10), OperationType = OperationType.InputCash, CashSum = 100m, AccountId = 1 },
                new OperationsHistory{Id = 4, OperationDate = DateTime.Now.AddDays(-15), OperationType = OperationType.InputCash, CashSum = 300m, AccountId = 2 },
                new OperationsHistory{Id = 5, OperationDate = DateTime.Now.AddDays(-5), OperationType = OperationType.OutputCash, CashSum = 100m, AccountId = 2 },
                new OperationsHistory{Id = 6, OperationDate = DateTime.Now.AddDays(-50), OperationType = OperationType.InputCash, CashSum = 5000m, AccountId = 3 },
                new OperationsHistory{Id = 7, OperationDate = DateTime.Now.AddDays(-30), OperationType = OperationType.InputCash, CashSum = 100m, AccountId = 4 },
                new OperationsHistory{Id = 8, OperationDate = DateTime.Now.AddDays(-30), OperationType = OperationType.InputCash, CashSum = 100m, AccountId = 5 },
                new OperationsHistory{Id = 9, OperationDate = DateTime.Now.AddDays(-70), OperationType = OperationType.InputCash, CashSum = 1000m, AccountId = 9 },
                new OperationsHistory{Id = 10, OperationDate = DateTime.Now.AddDays(-60), OperationType = OperationType.InputCash, CashSum = 500m, AccountId = 9 },
                new OperationsHistory{Id = 11, OperationDate = DateTime.Now.AddDays(-50), OperationType = OperationType.OutputCash, CashSum = 300m, AccountId = 9 },
                new OperationsHistory{Id = 12, OperationDate = DateTime.Now.AddDays(-40), OperationType = OperationType.InputCash, CashSum = 10500m, AccountId = 9 },
                new OperationsHistory{Id = 13, OperationDate = DateTime.Now.AddDays(-30), OperationType = OperationType.OutputCash, CashSum = 1000m, AccountId = 9 },
                new OperationsHistory{Id = 14, OperationDate = DateTime.Now.AddDays(-20), OperationType = OperationType.InputCash, CashSum = 300m, AccountId = 9 }
            }.AsQueryable();

        public void Dispose()
        {
            
        }
    }
}