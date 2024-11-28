using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Week12_Lab01_BankApp
{
    internal static class Logger
    {
        private static List<String> loginEvents = new List<string>();
        private static List<String> transactionEvents = new List<string>();

        public static void LoginHandler(Object sender, EventArgs args) {
            LoginEventArgs loginEventArgs = args as LoginEventArgs;
            String personName = loginEventArgs.PersonName;
            bool success = loginEventArgs.Success;
            DateTime dateTime = DateTime.Now;
            if (loginEventArgs != null) { 
               loginEvents.Add($"Person : {personName}, Success :{success}, DateTime : {dateTime}"); 
            }
        } 
        public static void TransactionHandler(Object sender, EventArgs args) {
            TransactionEventArgs transactionEventArgs = args as TransactionEventArgs;
            String personName = transactionEventArgs.PersonName;
            decimal amount = transactionEventArgs.Amount;
            String Operation = transactionEventArgs.Amount > 0 ? "Deposit" : "Withdraw";
            bool success = transactionEventArgs.Success;
            DateTime dateTime = DateTime.Now;
            if (transactionEventArgs != null)
            {
                transactionEvents.Add($"Person : {personName}, Amount : ${Math.Abs(amount)}CAD, Operation : {Operation}, Success :{success}, DateTime : {dateTime}");
            }
        }

        public static void ShowLoginEvents( string filename  ) { //---------
            List<String> lgnEvents = new List<string>();
            int lcounter = 1;
            foreach (String loginEvent in loginEvents) { 
                lgnEvents.Add($"{lcounter++} : " + loginEvent );
                Console.WriteLine( loginEvent );
            }
        }
        public static void ShowTransactionEvents( string filename  ) { //---------
            Console.WriteLine( DateTime.Now + "\n----------------------------");
            int tcounter = 1;
            foreach (String transactionEvent in transactionEvents) { 
                Console.WriteLine($"{tcounter++} : " + transactionEvent);
            }
        }
        public static void SaveLoginEvents(String filename){
            TextWriter wr = new StreamWriter(filename);
            String jsonData = JsonSerializer.Serialize(loginEvents);

            //Console.WriteLine(jsonData);
            wr.WriteLine(jsonData);

            wr.Close();
        }
        public static void SaveTransactionEvents(String filename){
            TextWriter wr = new StreamWriter(filename);
            String jsonData = JsonSerializer.Serialize(transactionEvents);

            //Console.WriteLine(jsonData);
            wr.WriteLine(jsonData);

            wr.Close();
        }

    }
}
