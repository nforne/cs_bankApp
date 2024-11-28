using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal class LoginEventArgs : EventArgs
    {
        public String PersonName {  get;  }
        public bool Success { get;  }

        public LoginEventArgs(string name, bool success) : base(){
            this.PersonName = name;
            this.Success = success;
        }

    }
}
