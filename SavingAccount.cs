using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06_lab18_Account_Class
{
    internal class SavingAccount : Account
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.015;

        public SavingAccount(double balance = 0, bool hasOverDraft = false) : base(ACCOUNT_TYPE.SV, balance) {}

        public new void Deposit(double amount, Person person)
        {
            if (IsHolder(person.Name))
            {
                Deposit(amount, person);
            }
        }

        public void Withdraw(double amount, Person person)
        {
            if (!IsHolder(person.Name))
            {
                throw new AccountException(EX.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            else if (!person.IsAuthenticated)
            {
                throw new AccountException(EX.USER_NOT_LOGGED_IN);
            }
            else if (amount > this.Balance)
            {
                throw new AccountException(EX.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            else
            {
                Deposit((-1 * amount), person);
            }

        }

        public override void PrepareMonthlyReport()
        {
            double serviceCharge = COST_PER_TRANSACTION * transactions.Count;
            double interest = (this.LowestBalance * INTEREST_RATE) / 12;

            this.Balance += interest;
            this.Balance -= serviceCharge;
            this.transactions.Clear();
        }
    }
}
