using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week06_lab18_Account_Class
{
    internal class Person
    {
        private string password;     
        public readonly string SIN;        
        public bool IsAuthenticated { get; private set; }        
        public string Name { get; }
        public Person(String name, String sin) {
            this.Name = name;
            this.SIN = sin;
            this.password = SIN.Substring(0, 3);
        }
        public void Login(String password) {
            if (this.password == password) {
                this.IsAuthenticated = true;
            }
            else
            {
                throw new AccountException(EX.PASSWORD_INCORRECT);
            }
        }
        public void Logout() { 
            this.IsAuthenticated = false;
        }        
        public override string ToString() {
            return $"Name : {this.Name}, IsAuthenticated : {this.IsAuthenticated}";
        }



    }
}
