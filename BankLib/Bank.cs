using System;
using System.Collections.Generic;

namespace BankLib
{
    //Statisk klasse, har valgt at gå denne vej i stedet for at bruge en database / teksfil
    public static class Bank
    {
        private static List<Account> accounts;
        private static List<Customer> customers;

        static Bank()
        {
            CreateCustomers();
            CreateAccounts();
            FixRelation();
        }

        //Opretter nogle kunder til test
        private static void CreateCustomers()
        {
            customers = new List<Customer>()
            {
                new Customer("Test","Testvej 1"),
                new Customer("Lars Jensen","Grenåvej 148")
            };
        }
        //Opretter nogle konti til test
        private static void CreateAccounts()
        {
            accounts = new List<Account>()
            {
                new Account("1234-78"),
                new Account("9876-12"),
                new Account("1111-22")
            };
            //Add balance to one account for testing purposes
            accounts[1].Balance = 1000;
        }
        //Sætter relationerne mellem kunde og konti
        private static void FixRelation()
        {
            //Fix relation for test
            customers[0].AddAccount(accounts[0]);
            customers[0].AddAccount(accounts[1]);
            accounts[0].AccountOwner = customers[0];
            accounts[1].AccountOwner = customers[0];
            //Fix relation for Lars jensen
            customers[1].AddAccount(accounts[2]);
            accounts[2].AccountOwner = customers[1];
        }
        //Retunerer en liste med alle kunder
        public static List<Customer> ReturnCustomers()
        {
            //Bedre practice og retunere en ny liste?
            //return new List<Customer>(customers);
            return customers;
        }

        //Find en kunde ud fra deres navn
        public static Customer GetCustomer(string name)
        {
            Customer result = null;
            bool isFound = true;
            foreach(Customer c in customers)
            {
                if(c.Name == name)
                {
                    isFound = false;
                    result = c;
                }

            }
            if(isFound)
            {
                //TOOO
            }
            return result;
        }
        //Find en konto udfra konto nr
        public static Account GetAccount(string accountNumber)
        {
            Account result = null;
            bool isFound = true;
            foreach (Account a in accounts)
            {
                if (a.AccountNumber == accountNumber)
                {
                    isFound = false;
                    result = a;
                }

            }
            if (isFound)
            {
                //TOOO
            }
            return result;
        }
        //Retunrer en liste med alle konti tilknyttet en kunde
        public static List<Account> GetCustomerAccounts(Customer c)
        {
            return c.Accounts;
        }

    }
}
