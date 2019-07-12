using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary;

namespace BankAplication
{
    class Bank<T> where T : Account
    {
        T[] accounts;
        string name;

        public Bank(string name)
        {
            this.name = name;
        }
        public void Add(T account)
        {
            BlueConsol(account);
            if (accounts == null)
                accounts = new T[] { account };
            else
            {
                if (isExist(account)) return;
                T[] tempAccounts = new T[accounts.Length + 1];
                accounts.CopyTo(tempAccounts, 0);
                tempAccounts[accounts.Length] = account;
                accounts = tempAccounts;
            }
        }
        public void Close(int id)
        {
            int i = FindIndexForID(id);
            if (i == -1) return;
            if (accounts.Length != 1)
                DelletedAccountsFromListForIndex(i);
            else
                accounts = null;
        }
        private void DelletedAccountsFromListForIndex(int i)
        {
            T[] tempAccounts = new T[accounts.Length - 1];
            for (int j = 0; j < i; j++)
                tempAccounts[j] = accounts[j];
            for (int j = i; j < accounts.Length - 1; j++)
                tempAccounts[j] = accounts[j + 1];
            accounts = tempAccounts;
        }
        internal void ChangeDeposit(int id)
        {
            TypeDeposit type;
            Console.WriteLine("What type you want: \n1: Bronze = 10%, 2: Silver = 20%, 3: Gold = 30%");
            switch (Console.ReadLine())
            {
                case "2":
                    type = TypeDeposit.Silver;
                    break;
                case "3":
                    type = TypeDeposit.Gold;
                    break;
                default:
                    type = TypeDeposit.Bronze;
                    break;
            }
            DepositAccount depositAccount = accounts[FindIndexForID(id)] as DepositAccount;
            depositAccount.changeDeposit(type);
            Console.WriteLine("You percent now: " + depositAccount.Percent + "%");
        }
        public void Put(decimal summ, int id)
        {
            FindAccountForID(id).Put(summ);
        }
        public void Withdraw(decimal withdraw, int id)
        {
            FindAccountForID(id).Withdraw(withdraw);
        }
        public T FindAccountForID(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                    return accounts[i];
            }
            throw new Exception("Dont find id");
            //return -1;
        }
        public void DayGone()
        {
            if (accounts == null) return;
            foreach (T acc in accounts)
            {
                acc.DayGone();
            }
        }
        public bool HasAccounts()
        {
            if (accounts == null) return false;
            return true;
        }

        private int FindIndexForID(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                    return i;
            }
            throw new Exception("Dont find id");
            //return -1;
        }
        private bool isExist(Account account)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Equals(account))
                {
                    Console.WriteLine("It's account already exists");
                    return true;
                }
            }
            return false;
        }
        private static void BlueConsol(T account)
        {
            account.Send += str =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(str);
                Console.ForegroundColor = ConsoleColor.Gray;
            };
        }
    }



}
