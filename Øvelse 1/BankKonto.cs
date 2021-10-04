using System;
using System.Collections.Generic;
using System.Text;

namespace Øvelse_1
{
    class BankKonto
    {
        public int Nummer { get; }
        public string Ejer { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Beløb;
                }

                return balance;
            }
            set { Balance = value; }
        }
        public int NummerSeed = 23939039;
        public BankKonto() : this("",1) { }
        public BankKonto(string navn, decimal initialBalance)
        {
            this.Ejer = navn;
            this.Nummer = NummerSeed;
            NummerSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initiel balance");
        }
        public List<Transaktion> allTransactions = new List<Transaktion>();
        public void MakeDeposit(decimal beløb, DateTime dato, string note)
        {
            if (beløb <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(beløb), "Amount of deposit must be positive");
            }
            var deposit = new Transaktion(beløb, dato, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal beløb, DateTime dato, string note)
        {
            if (beløb <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(beløb), "Amount of withdrawal must be positive");
            }
            if (Balance - beløb < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaktion(-beløb, dato, note);
            allTransactions.Add(withdrawal);
        }

    }
}
