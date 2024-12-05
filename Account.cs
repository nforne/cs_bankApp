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
        public readonly List<Transaction> transactions = new List<Transaction>();
        public virtual event EventHandler Onlogin;
        public virtual event EventHandler OnTransaction;
        public string Number {  get;}
        public decimal Balance { get; protected set; }
        public decimal LowestBalance { get; protected set; }

        public Account(string type, decimal balance) { 
            this.users = new List<Person>();
            this.Number = type + LAST_NUMBER; ;
            LAST_NUMBER++;
            (this.Balance, this.LowestBalance) = (balance, balance);
        
        }

        public void Deposit(decimal balance, Person person) {
            if (this.Balance + balance >= this.LowestBalance)
            {
                this.Balance += balance;
            }
            else
            {
                //Console.WriteLine($"Amount request not allowed :" +
                //    $"\n    CurrentBalance = ${this.Balance}CAD" +
                //    $"\n    LowestBalance allowed = ${this.LowestBalance}CAD" +
                //    $"\n    Requested amount = ${balance}CAD");
                return;
            }

            transactions.Add(new Transaction(this.Number, balance, person, Utils.Now));
            
        }
        public void AddUser( Person person) {
            this.users.Add(person);
        }
        public bool IsUser( String name) {
            bool result = false;
            foreach (Person person in this.users) {
                if (person.Name.Equals(name)){
                    result = true;
                    break;
                }
            }
            return result;
        }
        public virtual void OnTransactionOccur(Object sender, EventArgs args) {
            this.OnTransaction.Invoke(sender, args);
        }

        public virtual void OnLoginOccur(Object sender, EventArgs args)
        {
            this.Onlogin.Invoke(sender, args);
        }

        public abstract void PrepareMonthlyStatement();

        public override string ToString() {
            String outPut = "";
            outPut += $"AccountNumber : {this.Number}, ";

            String holdersNames = "";
            foreach (Person p in this.users)
            {
                string commaOrNot = this.users[this.users.Count - 1] == p ? "" : ", ";
                holdersNames += p.Name + commaOrNot;
            }

            outPut += $"\n  AccountHolder(s) : {holdersNames}, ";
            outPut += $"\n  AccountBalance : {this.Balance}, ";
            outPut += $"\n  AccountTransactions : \n{String.Join(", \n", this.transactions)}\n";

            return outPut;
        }

    }
}
