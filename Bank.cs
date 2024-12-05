using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week12_Lab01_BankApp
{
    internal class Bank
    {
        public static readonly Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>();
        public static readonly Dictionary<string, Person> USERS = new Dictionary<string, Person>();

        public Bank() {
            //initialize the USERS collection
            AddPerson("Narendra", "1234-5678"); //0
            AddPerson("Ilia", "2345-6789"); //1
            AddPerson("Mehrdad", "3456-7890"); //2
            AddPerson("Vinay", "4567-8901"); //3
            AddPerson("Arben", "5678-9012"); //4
            AddPerson("Patrick", "6789-0123"); //5
            AddPerson("Yin", "7890-1234"); //6
            AddPerson("Hao", "8901-2345"); //7
            AddPerson("Jake", "9012-3456"); //8
            AddPerson("Mayy", "1224-5678"); //9
            AddPerson("Nicoletta", "2344-6789"); //10

            //initialize the ACCOUNTS collection
            AddAccount(new VisaAccount()); //VS-100000
            AddAccount(new VisaAccount(150, -500)); //VS-100001
            AddAccount(new SavingAccount(5000)); //SV-100002
            AddAccount(new SavingAccount()); //SV-100003
            AddAccount(new CheckingAccount(2000)); //CK-100004
            AddAccount(new CheckingAccount(1500, true));//CK-100005
            AddAccount(new VisaAccount(50, -550)); //VS-100006
            AddAccount(new SavingAccount(1000)); //SV-100007
            
            //associate users with accounts
            string number = "VS-100000";
            AddUserToAccount(number, "Narendra");
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Mehrdad");
            number = "VS-100001";
            AddUserToAccount(number, "Vinay");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Patrick");
            number = "SV-100002";
            AddUserToAccount(number, "Yin");
            AddUserToAccount(number, "Hao");
            AddUserToAccount(number, "Jake");
            number = "SV-100003";
            AddUserToAccount(number, "Mayy");
            AddUserToAccount(number, "Nicoletta");
            number = "CK-100004";
            AddUserToAccount(number, "Mehrdad");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Yin");
            number = "CK-100005";
            AddUserToAccount(number, "Jake");
            AddUserToAccount(number, "Nicoletta");
            number = "VS-100006";
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Vinay");
            number = "SV-100007";
            AddUserToAccount(number, "Patrick");
            AddUserToAccount(number, "Hao");

        }
        public static void AddPerson(String name, String sin){
            AddUser(name, sin);
        }
        public static void AddUser(String name, String sin) { 
            Person p = new Person(name, sin);
            p.OnLogin += Logger.LoginHandler;
            USERS.Add(sin, p); 
        }
        public static void AddAccount(Account account){
            account.OnTransaction += Logger.TransactionHandler;
            ACCOUNTS.Add(account.Number, account);        
        }
        public static void AddUserToAccount(String number, String name){
            GetAccount(number).AddUser(GetUser(name));
        }
        public static Account GetAccount(String number){
            if (ACCOUNTS.Keys.Contains(number))
            {
                return ACCOUNTS[number];
            }
            else
            {
                throw new AccountException(ExceptionType.ACCOUNT_DOES_NOT_EXIST);
            };
        }
        public static Person GetUser(String name){
            Person p = null;
            foreach (String key in USERS.Keys)
            {
                if (USERS[key].Name.Equals(name)) { p = USERS[key]; break; }
            }
            try
            {                            
                if (p == null)
                {
                    throw new AccountException(ExceptionType.USER_DOES_NOT_EXIST);
                };                
            }
            catch (AccountException e) {
                Console.WriteLine(e.Message);
            }
            return p;

        }
        public static void SaveAccounts(String filename){
            TextWriter wr = new StreamWriter(filename + ".txt");
            String jsonData = JsonSerializer.Serialize(ACCOUNTS);            
            wr.WriteLine(jsonData);
            wr.Close();
        }
        public static void SaveUsers(String filename){
            TextWriter wr = new StreamWriter(filename + ".txt");
            String jsonData = JsonSerializer.Serialize(USERS);
            wr.WriteLine(jsonData);
            wr.Close();
        }
        public static List<Transaction> GetAllTransactions(String filename){

            List<Transaction> allTransactions = new List<Transaction>();
            foreach (String acc in ACCOUNTS.Keys) {
                allTransactions.AddRange(ACCOUNTS[acc].transactions);
            }

            TextWriter wr = new StreamWriter(filename);
            String jsonData = JsonSerializer.Serialize(allTransactions);
            wr.WriteLine(jsonData);
            wr.Close();


            return allTransactions;

        }

        public static void PrintAccounts()
        {
            foreach (String acc in ACCOUNTS.Keys) {
                Console.WriteLine(ACCOUNTS[acc]);
            }
        }

        public static void PrintPersons()
        {           
            foreach (String user in USERS.Keys) {
                Console.WriteLine(USERS[user]);
            }
        }
    }
}
