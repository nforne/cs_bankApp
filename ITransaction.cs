using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal interface ITransaction
    {
        void Withdraw(decimal amount, Person person);
        void Deposit(decimal amount, Person person);
    }
}
