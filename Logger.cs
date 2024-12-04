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
            if (loginEventArgs != null) { 
               loginEvents.Add($"Person : {personName}, Success :{success}, DateTime : {Utils.Now}"); 
            }

            SaveLoginEvents("LoginData.json");
        } 
        public static void TransactionHandler(Object sender, EventArgs args) {
            TransactionEventArgs transactionEventArgs = args as TransactionEventArgs;
            String personName = transactionEventArgs.PersonName;
            decimal amount = transactionEventArgs.Amount;
            String Operation = transactionEventArgs.Amount > 0 ? "Deposit" : "Withdraw";
            bool success = transactionEventArgs.Success;            
            if (transactionEventArgs != null)
            {
                transactionEvents.Add($"Person : {personName}, Amount : ${Math.Abs(amount)}CAD, Operation : {Operation}, Success :{success}, DateTime : {Utils.Now}");
            }

            SaveTransactionEvents("TransactionsData.json");
        }

        public static void ShowLoginEvents( string filename ) { //---------            
            Console.WriteLine("Showing all login events : " + Utils.Now + "\n----------------------------");
            TextReader rd = new StreamReader($"{filename}.json");
            String jsonData = rd.ReadToEnd();
            List<String> loginEvList = JsonSerializer.Deserialize<List<String>>(jsonData);
            int lcounter = 1;
            foreach (String loginEv in loginEvList)
            {
                Console.WriteLine($"{lcounter++} : " + loginEv);
                
            }
            rd.Close();          
            
        }
        public static void ShowTransactionEvents( string filename  ) { //---------
            Console.WriteLine("Showing all Transaction events : " + Utils.Now + "\n----------------------------");
            TextReader rd = new StreamReader($"{filename}.json");
            String jsonData = rd.ReadToEnd();
            List<String> transactionsEvList = JsonSerializer.Deserialize<List<String>>(jsonData);
            int lcounter = 1;
            foreach (String tansactionEv in transactionsEvList)
            {
                Console.WriteLine($"{lcounter++} : " + tansactionEv);

            }
            rd.Close();
        }
        public static void SaveLoginEvents(String filename){
            TextWriter wr = new StreamWriter(filename);
            String jsonData = JsonSerializer.Serialize(loginEvents);            
            wr.WriteLine(jsonData);
            wr.Close();
        }
        public static void SaveTransactionEvents(String filename){
            TextWriter wr = new StreamWriter(filename);
            String jsonData = JsonSerializer.Serialize(transactionEvents);            
            wr.WriteLine(jsonData);
            wr.Close();
        }

    }
}
