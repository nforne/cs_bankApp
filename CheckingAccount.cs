using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Week06_lab18_Account_Class.Account;

namespace Week06_lab18_Account_Class
{
    internal class CheckingAccount : Account
    {
        static double COST_PER_TRANSACTION = 0.05;
        static double INTEREST_RATE  = 0.005;

        private bool hasOverdraft;
        public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base(ACCOUNT_TYPE.CK, balance) { 
            this.hasOverdraft = hasOverdraft;
        }

        public new void Deposit(double amount, Person person) {
            if (IsHolder(person.Name)) { 
                Deposit(amount, person);
            }
        }
        

        public void Withdraw(double amount, Person person) {
            if (!IsHolder(person.Name))
            {
                throw new AccountException(EX.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            else if (!person.IsAuthenticated)
            {
                throw new AccountException(EX.USER_NOT_LOGGED_IN);
            }
            else if (amount > this.Balance && !hasOverdraft)
            {
                throw new AccountException(EX.NO_OVERDRAFT);
            }
            else {
                Deposit((-1 * amount), person);
            }

        }

        public override void PrepareMonthlyReport()
        {
            double serviceCharge = COST_PER_TRANSACTION * transactions.Count;
            double interest = (this.Balance * INTEREST_RATE) / 12;

            this.Balance += interest;
            this.Balance -= serviceCharge;
            this.transactions.Clear();
        }


    }
}
