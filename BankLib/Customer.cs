using System;
using System.Collections.Generic;
using System.Text;

namespace BankLib
{
    public class Customer
    {
        //Navn på kunden
        public string Name { get; private set; }
        //Kundens adresse
        public string Address { get; private set; }
        //Liste af konti tilknyttet kunden
        public List<Account> Accounts;
        //Constructor til at oprette en kunde
        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
            Accounts = new List<Account>();
        }
        //Override af ToString - bruges i combobox
        public override string ToString()
        {
            return Name;
        }
        //Retunrer en liste af kundens konti
        public List<Account> GetAccounts()
        {
            return Accounts;
        }
        //Tilføjer en konto til kunden
        public void AddAccount(Account a)
        {
            Accounts.Add(a);
        }
    }
}
