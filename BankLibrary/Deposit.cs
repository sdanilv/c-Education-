﻿using System;
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
    }
    public enum TypeDeposit
    {
        Bronze = 10,
        Silver = 20,
        Gold = 30
    }
}
