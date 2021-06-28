using System;
using System.Collections.Generic;
using System.Text;

namespace BankLib
{
    public class Account
    {
        //Kontonr
        public string AccountNumber { get;  set; }
        //Saldo
        public decimal Balance { get;  set; }

        //Delte konti er ikke supported på nuværende tidspunkt
        public Customer AccountOwner { get; set; }

        //Liste af transaktioner - ikke implementeret
        public List<Transaction> transactions;

        //Constructor til at lave en account, sætter default saldo til at være 0
        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
            transactions = new List<Transaction>();
        }

        //Funktion til at indsætte penge på konto
        public void Deposit(decimal amount)
        {
            //Ingen pointe i at lave en transaktion hvis beløbet er 0
            if(amount > 0)
            {
                Balance += amount;
                Transaction t = new Transaction(amount, "Deposit", DateTime.Now, this);
                transactions.Add(t);
            }
        }

        //Funktion til at hæve penge fra konto
        public void Withdraw(decimal amount)
        {
            //Ingen pointe i at lave en transaktion hvis beløbet er 0
            if (amount > 0)
            {
                //TODO: Implementer
                if (amount > Balance)
                {

                }
                else
                {
                    Balance -= amount;
                    Transaction t = new Transaction(amount, "Withdrawal", DateTime.Now, this);
                    transactions.Add(t);
                }
            }

        }
        //Henter transaktioner - ikke implementeret
        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

    }
}
