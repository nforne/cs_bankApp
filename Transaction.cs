using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06_lab18_Account_Class
{
    struct Transaction
    {
        public String AccountNumber { get; }
        public double Amount { get; }        
        public double EndBalance { get; }        
        public Person Originator { get; }        
        public DateTime Time { get; }        
        public Transaction(string accountNumber, double amount, double endBalance, Person person, DateTime time)
        {
            this.AccountNumber = accountNumber;
            this.Amount = amount;   
            this.EndBalance = endBalance;            
            this.Originator = person;
            this.Time = time;          
        }
      
        public override String ToString()
        {
            string transactionType = this.EndBalance > this.Amount ? "Deposit" : "Withdraw";
            return $"Transaction Type: {transactionType}" +
                $"\n    Account Number : {this.AccountNumber}, Transaction Originator : {this.Originator.Name}, Amount : {this.Amount}, Transaction Time : {this.Time.ToShortTimeString()} ";
        }


    }
}
