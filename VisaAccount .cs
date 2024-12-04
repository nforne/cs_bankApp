using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal class VisaAccount : Account
    {
        private decimal creditLimit;
        private static decimal INTEREST_RATE = 0.1995m;

        public VisaAccount(decimal balance = 0, decimal creditLimit = 1200) : base(AccType.VS, balance) { 
            this.creditLimit = creditLimit;
        }

        public void DoPayment(decimal amount, Person person)
        {
            this.Deposit(amount, person);
            Transaction t = new Transaction(this.Number, amount, person, Utils.Now);
            TransactionEventArgs te = new TransactionEventArgs(person.Name, amount, this.Balance + amount >= this.LowestBalance);
            OnTransactionOccur(t, te);
        }
        public void DoPurchase(decimal amount, Person person)
        {
            bool success = false;
            Transaction t = new Transaction(this.Number, amount, person, Utils.Now);
            TransactionEventArgs te = new TransactionEventArgs(person.Name, amount, success);

            if (!this.IsUser(person.Name))
            {
                this.OnTransactionOccur(t, te);
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            else if (!person.IsAuthenticated)
            {
                this.OnTransactionOccur(t, te);
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }
            else if (amount > this.creditLimit || amount > (this.Balance - this.LowestBalance))
            {
                this.OnTransactionOccur(t, te);
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            else
            {
                success = amount <= this.creditLimit && amount <= (this.Balance - this.LowestBalance);
                this.OnTransactionOccur(t, te);
                this.Deposit((-1 * amount), person);
                this.transactions.Add(t);
            };


        }

        public override void PrepareMonthlyStatement()
        {            
            decimal interest = ((this.creditLimit - this.Balance) * INTEREST_RATE) / 12;
            this.Balance -= interest;            
            this.transactions.Clear();
        }
    }
}
