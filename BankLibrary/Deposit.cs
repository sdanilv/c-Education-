using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        private int percent;
        private int days;
        public int Percent { get => percent; }
        public int Days { get => days; private set => days = value; }
        public DepositAccount(decimal sum, TypeDeposit type) : base("DEPOSIT", sum)
        {
            percent = (int)type;
            days = 0;
        }

        public override void DayGone()
        {
            Put(AmmountMoney * Percent / 100);
        }

        public decimal AmountOfIncome(int month)
        {
            decimal depos = AmmountMoney;

            decimal counter(decimal summ)
            {
                return summ + summ * Percent / 100;
            }
            for (int i = 0; i < month; i++)
            {
                depos = counter(depos);
            }
            return depos;

        }
        public DepositAccount changeDeposit(TypeDeposit type) {
            percent = (int)type;
            return this;
        }

    }
    public enum TypeDeposit
    {
        Bronze = 10,
        Silver = 20,
        Gold = 30
    }
}
