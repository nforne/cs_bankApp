using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal class AccountException : Exception
    {
        public AccountException() : base() { }

        public AccountException(ExceptionType reason) : base(reason.ToString()) { }
    }
}
