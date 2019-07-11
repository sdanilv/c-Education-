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

        public void Open(T account)
        {
            if (accounts == null)
                accounts = new T[] { account };
            else
                for (int i = 0; i < accounts.Length; i++)
                {
                    if (accounts[i].Equals(account))
                    {
                        Console.WriteLine("It's account already exists");
                        return;
                    }
                }

            T[] tempAccounts = new T[accounts.Length + 1];
            accounts.CopyTo(tempAccounts, 0);
            tempAccounts[accounts.Length] = account;
            accounts = tempAccounts;
        }

        public void Close(int id)
        {
            int i = FindIndexForID(id);
            if (i == -1) return;

            accounts[i].DeleteAcount();
            T[] tempAccounts = new T[accounts.Length - 1];

            for (int j = 0; j < i; j++)
            {
                tempAccounts[j] = accounts[j];

            }
            for (int j = i; j < accounts.Length; j++)
            {

                tempAccounts[j - 1] = accounts[j];
            }
            accounts = tempAccounts;
        }


        public void Put(decimal summ, int id)
        {
            FindAccountForID(id).Put(summ);
        }

        public void Withdraw(decimal withdraw, int id)
        {
            FindAccountForID(id).Withdraw(withdraw);
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

        private T FindAccountForID(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                    return accounts[i];
            }
            throw new Exception("Dont find id");
            //return -1;
        }

        public static implicit operator Bank<T>(Bank<DepositAccount> v)
        {
            throw new NotImplementedException();
        }
    }



}
