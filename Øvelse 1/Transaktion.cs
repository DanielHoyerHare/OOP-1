using System;
using System.Collections.Generic;
using System.Text;

namespace Øvelse_1
{
    public class Transaktion
    {
        //Transaktions propertys
        public decimal Beløb { get; }
        public DateTime Dato { get; }
        public string Noter { get; }
        //Constructor som bruges til at sætte propertys i classen
        public Transaktion(decimal beløb, DateTime dato, string note)
        {
            this.Beløb = beløb;
            this.Dato = dato;
            this.Noter = note;
        }
    }
}





