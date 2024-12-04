using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal class SavingAccount : Account, ITransaction
    {
        private static decimal COST_PER_TRANSACTION = 0.5m;
        private static decimal INTEREST_RATE = 0.015m;

        public SavingAccount(decimal balance = 0) : base(AccType.SV, balance) { }         
        
        public new void Deposit(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            Transaction t = new Transaction(this.Number, amount, person, Utils.Now);
            TransactionEventArgs te = new TransactionEventArgs(person.Name, amount, this.Balance + amount >= this.LowestBalance);
            OnTransactionOccur(t, te);
        }
        public void Withdraw(decimal amount, Person person)
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
            else if (amount > (this.Balance - this.LowestBalance) )
            {
                this.OnTransactionOccur(t, te);
                throw new AccountException(ExceptionType.NO_OVERDRAFT_FOR_THIS_ACCOUNT);
            }
            else
            {
                success = this.Balance + (-1 * amount) >= this.LowestBalance;
                this.OnTransactionOccur(t, te);
                base.Deposit((-1 * amount), person);
                this.transactions.Add(t);
            };


        }

        protected override void PrepareMonthlyStatement()
        {
            decimal serviceCharge = COST_PER_TRANSACTION * this.transactions.Count;
            decimal interest = (this.Balance * INTEREST_RATE) / 12;

            this.Balance += interest;
            this.Balance -= serviceCharge;
            this.transactions.Clear();
        }
    }
}
