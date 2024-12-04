using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal enum AccountType
    {
        Checking,
        Saving,
        Visa,
        Line_of_credit
    }

    internal class AccType
    {
        public static readonly String VS = "VS-"; // visa
        public static readonly String SV = "SV-"; // savings
        public static readonly String CK = "CK-"; // chequing          

    }
}
