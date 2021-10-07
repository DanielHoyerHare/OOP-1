using System;
using System.Collections.Generic;
using System.Text;

namespace Øvelse_1
{
    class BankKonto
    {
        //Objekters propertys
        public int Nummer { get; }
        public string Ejer { get; set; }
        public decimal Balance
        {
            get
            {
                //Saldo udregnes ud fra alle tidligere transaktioner
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Beløb;
                }

                return balance;
            }
            set { Balance = value; }
        }
        //Startnummer for kortnumre
        public int NummerSeed = 23939039;
        //Hvis objekt oprettes uden nogen parametre vil den selv udfylde det med ukendt som navn og 1 som saldo
        public BankKonto() : this("Ukendt",1) { }
        //Oprettelse af objekt
        public BankKonto(string navn, decimal initialBalance)
        {
            this.Ejer = navn;
            this.Nummer = NummerSeed;
            NummerSeed++;
            //MakeDeposit metoden bruges til at sætte saldoen ved at gemme det som en transaktion
            MakeDeposit(initialBalance, DateTime.Now, "Initiel balance");
        }
        //Liste der indeholder alle transaktioner
        public List<Transaktion> allTransactions = new List<Transaktion>();
        //Metode står for at penge kan indsættes
        public void MakeDeposit(decimal beløb, DateTime dato, string note)
        {
            if (beløb <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(beløb), "Amount of deposit must be positive");
            }
            //opretter nyt transaktion objekt
            var deposit = new Transaktion(beløb, dato, note);
            //gemmer transaktions objekt i listen
            allTransactions.Add(deposit);
        }
        //Metode står for hævning af penge
        //Fungere ligesom deposit udover den også tjekker om man har nok penge
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
            //Opretter transaktion men sætter beløb til minus så penge fjernes
            var withdrawal = new Transaktion(-beløb, dato, note);
            allTransactions.Add(withdrawal);
        }

    }
}
