using System;
using System.Collections.Generic;
using System.Text;

namespace BankLib
{
    public class Transaction
    {

        //Beløbet der er involveret i transaktionen
        public decimal Amount { get; set; }
        //Type af transaktion - Indsæte/Hæve
        public string Type { get; set; }
        //Tidspunkt for transaktionen
        public DateTime TransTime { get; set; }
        //Den tilhørende konto
        public Account Account { get; set; }

        //Constructor til at oprette en transaktion
        public Transaction(decimal amount, string type, DateTime transTime, Account account)
        {
            Amount = amount;
            Type = type;
            TransTime = transTime;
            Account = account;
        }
    }
}
