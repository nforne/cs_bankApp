using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week06_lab18_Account_Class
{
    internal class Bank
    {
        private static List<Account> accounts;
        private static List<Person> persons;

        static Bank() {

            Initialize();          

        }

        private static void CreatePersons()
        {
           persons = new List<Person>(){
                new Person("Narendra", "1234-5678"),
                new Person("Ilia", "2345-6789"),
                new Person("Tom", "3456-7890"),
                new Person("Syed", "4567-8901"),
                new Person("Arben", "5678-9012"),
                new Person("Patrick", "6789-0123"),
                new Person("Yin", "7890-1234"),
                new Person("Hao", "8901-2345"),
                new Person("Jake", "9012-3456")
           };

        }

        private static void CreateAccounts() {
            accounts = new List<Account>{
                new VisaAccount(),              //VS-100000
                new VisaAccount(550, -500),     //VS-100001
                new SavingAccount(5000),        //SV-100002
                new SavingAccount(),            //SV-100003
                new CheckingAccount(2000),      //CK-100004
                new CheckingAccount(1500, true) //CK-100005
            };

        }

        public static void Initialize()
        {
            CreateAccounts();
            CreatePersons();
            accounts[0].AddUser(persons[0]);
            accounts[0].AddUser(persons[1]);
            accounts[0].AddUser(persons[2]);

            accounts[1].AddUser(persons[3]);
            accounts[1].AddUser(persons[4]);
            accounts[1].AddUser(persons[2]);

            accounts[2].AddUser(persons[0]);
            accounts[2].AddUser(persons[5]);
            accounts[2].AddUser(persons[6]);

            accounts[3].AddUser(persons[5]);
            accounts[3].AddUser(persons[6]);

            accounts[4].AddUser(persons[5]);
            accounts[4].AddUser(persons[7]);
            accounts[4].AddUser(persons[8]);

            accounts[5].AddUser(persons[5]);
            accounts[5].AddUser(persons[6]);
        }

        public static void PrintAccounts() {
            Console.WriteLine("Displaying All Accounts \n==================================");
            foreach(Account a in accounts)
            {
                Console.WriteLine(a);
            }
        }

        public static void SaveAccounts(string filename) {
            TextWriter wr = new StreamWriter(filename);
            String jsonData = JsonSerializer.Serialize(accounts);

            //Console.WriteLine(jsonData);
            Console.WriteLine("\nSaving All Accounts in JSON format to text file ....\n==================================");
            wr.WriteLine(jsonData);

            wr.Close();

        }

        public static void PrintPersons() {
            Console.WriteLine("Displaying All Persons \n==================================");
            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
        }

        public static Person GetPerson(string name) {
            //Console.WriteLine($"Getting Person with Name : {name} \n==================================");
            Person person = null;
            foreach (Person p in persons)
            {
                if (p.Name == name) { 
                    person = p;
                    break;
                }
            }
            if (person == null)
            {
                throw new AccountException(EX.USER_DOES_NOT_EXIST);
            }
            else { 
                return person;
            }
        }

        public static Account GetAccount(string number) {
            Console.WriteLine($"Getting Account with Number : {number} \n==================================");
            Account account = null;
            foreach (Account a in accounts)
            {
                if (a.Number == number)
                {
                    account = a;
                    break;
                }
            }
            if (account == null)
            {
                throw new AccountException(EX.ACCOUNT_DOES_NOT_EXIST);
            }
            else
            {
                return account;
            }
        }
    }

}
