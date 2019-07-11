using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    interface IAccount
    {
        void Put(decimal summ);
        decimal Withdraw(decimal with);
    }
}
