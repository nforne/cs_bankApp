using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week06_lab18_Account_Class
{
    internal abstract class Account
    {
        public static AccountType ACCOUNT_TYPE = new AccountType();

        private static int LAST_NUMBER;
        
        private static int CURRENT_NUMBER;
        
        protected List<Transaction> transactions = new List<Transaction>();
        
        protected List<Person> holders = new List<Person>();
        
        public readonly String Number;        
        public double Balance {  get; protected set; }        
        public double LowestBalance { get; protected set; }       
        public Account(String type, double balance) { 
            this.Balance = balance;
            this.LowestBalance = balance;
            this.Number = type + "-" + LAST_NUMBER;
            LAST_NUMBER++;
        }       
        public void AddUser(Person person) { 
            holders.Add(person);
        }
        //+ Deposit(amount : double, person : Person) : void
        public void Deposit(double amount, Person person) {
            this.Balance += amount;
            this.LowestBalance = this.Balance;
            Transaction transaction = new Transaction(this.Number, amount, this.Balance, person, DateTime.Now);
            transactions.Add(transaction);
        }
       
        public bool IsHolder(String name) { 
            bool isHolder = false;
            foreach(Person p in this.holders) {
                if (p.Name == name) {
                    isHolder = true;
                    break;
                }; 
            }    
            return isHolder; 
        }
        
        public abstract void PrepareMonthlyReport();
        
        public override string ToString() {
            String outPut = "";
            outPut += $"AccountNumber : {this.Number}, ";

            String holdersNames = "";
            foreach (Person p in this.holders)
            {
                string commaOrNot = this.holders[this.holders.Count - 1] == p ? "" : ", ";
                holdersNames += p.Name + commaOrNot;
            }

            outPut += $"\n  AccountHolder(s) : {this.Number}, ";
            outPut += $"\n  AccountBalance : {this.Balance}, ";
            outPut += $"\n  AccountTransactions : \n{String.Join(", \n", this.transactions)}\n";

            return outPut;
        }

        public class AccountType {
            public readonly String VS = "VS"; // visa
            public readonly String SV = "SV"; // savings
            public readonly String CK = "CK"; // chequing 
        }


    }
}
