using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06_lab18_Account_Class
{    
    internal class AccountException : Exception
    {
        public AccountException() : base() { }
        
        public AccountException(String reason) : base(reason) { }


    }

    public class EX
    {      
        public static readonly String ACCOUNT_DOES_NOT_EXIST = "ACCOUNT_DOES_NOT_EXIST";
        public static readonly String CREDIT_LIMIT_HAS_BEEN_EXCEEDED = "CREDIT_LIMIT_HAS_BEEN_EXCEEDED";
        public static readonly String NAME_NOT_ASSOCIATED_WITH_ACCOUNT = "NAME_NOT_ASSOCIATED_WITH_ACCOUNT";
        public static readonly String NO_OVERDRAFT = "NO_OVERDRAFT";
        public static readonly String PASSWORD_INCORRECT = "PASSWORD_INCORRECT";
        public static readonly String USER_DOES_NOT_EXIST = "USER_DOES_NOT_EXIST";
        public static readonly String USER_NOT_LOGGED_IN = "USER_NOT_LOGGED_IN";
        
    }

}
