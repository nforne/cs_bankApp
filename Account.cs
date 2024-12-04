using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal abstract class Account
    {
        private static int LAST_NUMBER = 100_000;
        protected readonly List<Person> users;
        public readonly List<Transaction> transactions;
        public virtual event EventHandler Onlogin;
        public virtual event EventHandler OnTransaction;
        public string Number {  get;}
        public decimal Balance { get; protected set; }
        public decimal LowestBalance { get; protected set; }

        public Account(string type, decimal balance) { 
            this.users = new List<Person>();
        
        }

        public void Deposit(decimal balance, Person person) { }
        public void AddUser( Person person) { }
        public bool IsUser( String name) {
            return true;
        }
        public virtual void OnTransactionOccur(Object sender, EventArgs args) { }

        protected abstract void PrepareMonthlyStatement();

        public override string ToString() { 
            return this.ToString();
        }

    }
}
