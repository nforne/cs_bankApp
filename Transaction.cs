using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal struct Transaction
    {
        public String AccountNumber {  get;  }
        public decimal Amount {  get;  }        
        public Person Originator { get;  }
        public DayTime Time { get;  }

        public Transaction(string accountNumber, decimal amount, Person person, DayTime time) { 
            this.AccountNumber = accountNumber;
            this.Amount = amount;
            this.Originator = person;
            this.Time = time;
        }

        public override string ToString() {
            string transactionType = this.Amount >= 0 ? "Deposit" : "Withdraw";
            return $"Transaction Type: {transactionType}" +
                $"\n    Account Number : {this.AccountNumber}, Transaction Originator : {this.Originator.Name}, Amount : {this.Amount}, Transaction Time : {this.Time.ToShortTimeString()} ";
        }
    }
}
