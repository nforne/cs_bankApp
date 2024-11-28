using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal class Person
    {
        private String password;
        public event EventHandler OnLogin; // -----------------------
        public String SIN { get;  }
        public String Name {  get;  }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin) {
            this.Name = name;
            this.SIN = sin;
            this.password = this.SIN.Substring(0, 3);
        }

        public void Login(string password) {
            if (password != this.password)
            {
                this.IsAuthenticated = false;

                this.OnLogin.Invoke(this, new LoginEventArgs(this.Name, this.IsAuthenticated));
                throw new AccountException(ExceptionType.PASSWORD_INCORRECT);

            }
            else { 
                
            }
        }
        public void Logout() { }
        
        public override String ToString() {
            return this.ToString();
        }
    }
}
