using System;

namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        private decimal ammountMoney;
        private int id;
        static int staticId;
        private string typeOfAccount;
        //private string fullName;    
        public decimal AmmountMoney { get => ammountMoney; private set => ammountMoney = value; }
        public int Id { get => id;  }
        public delegate void Messenger(String s);
        public event Messenger Send;
    
        public bool Equals(Account acc)
        {
            return Id == acc.Id;         
        }
        public virtual void DeleteAcount()
        {
            this.id = -1;
            Withdraw(ammountMoney + 1);
            Send($"{typeOfAccount} account {Id} delleted");
        }
        public virtual void Put(decimal summ)
        {
            AmmountMoney += summ;
            Send($"You recive {summ}$ into you {typeOfAccount} account {Id}. Now {AmmountMoney}$.");
        }
        public virtual decimal Withdraw(decimal withdraw)
        {
            if (AmmountMoney < withdraw)
            {
                Send("You have not money in the account");
                return AmmountMoney;
            }
            AmmountMoney -= withdraw;
            Send($"You pay {withdraw}$. Now in you {typeOfAccount} account  {Id}  {AmmountMoney}$");
            return AmmountMoney;
        }
        public virtual void DayGone() {}
        public Account(string type) : this(type, 0) { }
        public Account(string type, decimal sum)
        {
            typeOfAccount = type;
            this.id = staticId++;
            ammountMoney = sum;
        }
        public override string ToString()
        {
            return $"This {typeOfAccount} account, has id {Id}";
        }
    }
}
