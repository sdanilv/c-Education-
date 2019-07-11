﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class CreditAccount : Account
    {
        private int percent;
        private int days;
        private int duration;
        private decimal Credit { set; get; } = 0;
        public int Percent { get => percent; }
        public int Days { get => days; private set => days = value; }


        public override void Put(decimal summ)
        {
            if (Credit == 0)
            {
                base.Put(summ);
                return;
            }
            Credit -= summ;
        }
        public override decimal Withdraw(decimal withdraw)
        {
            if (AmmountMoney <= withdraw)
            {
                Credit += withdraw - AmmountMoney;
                base.Withdraw(AmmountMoney);
                percent = loanInterestCalculation(duration);
                days = 0;
                return 0;
            }

            return base.Withdraw(withdraw);
        }
        public CreditAccount(int sum, int lasting, decimal credit) : base("CREDIT", sum)
        {
            Credit = credit;
            duration = lasting;
        }
        public CreditAccount(int sum, int lasting) : base("CREDIT", sum) 
        {
            Credit = 0;
            duration = lasting;
        }

        private int loanInterestCalculation(int continuance)
        {
            return continuance / 150;
        }

        public decimal creditAfterDuration()
        {
            decimal summ = Credit;
            for (int i = 0; i < duration / 30; i++)
            {
                summ = creditAfterMonth(summ);
            }
            return summ;
        }


        public decimal creditAfterMonth(decimal summ)
        {
            return summ + summ * percent / 100;
        }

    }

}
