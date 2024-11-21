using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week06_lab18_Account_Class.Account;

namespace Week06_lab18_Account_Class
{
    internal class VisaAccount : Account
    {
        private static double INTEREST_RATE = 0.1995;
        private double credilLimit;

        public VisaAccount(double balance = 0, double creditLimit = 1200) : base(ACCOUNT_TYPE.VS, balance)
        {
            this.credilLimit = creditLimit;
        }
 
        public void DoPayment(double amount, Person person) {
            
            Deposit(amount, person);
            
        }

        //+ DoPurchase(amount: double, person Person) : : void
        public void DoPurchase(double amount, Person person) {
            if (!IsHolder(person.Name))
            {
                throw new AccountException(EX.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            else if (!person.IsAuthenticated)
            {
                throw new AccountException(EX.USER_NOT_LOGGED_IN);
            }
            else if (amount > this.credilLimit)
            {
                throw new AccountException(EX.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            else
            {
                Deposit((-1 * amount), person);
            }
        }

        //+ PrepareMonthlyReport() : : void
        public override void PrepareMonthlyReport()
        {            
            double interest = (this.LowestBalance * INTEREST_RATE) / 12;
            
            this.Balance -= interest;
            this.transactions.Clear();
        }
    }

}
