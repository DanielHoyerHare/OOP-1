using System;

namespace Øvelse_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bankkonto objektet bliver oprettet nu uden information for at kunne bruges senere i programmet
            BankKonto p = new BankKonto();
            //Exit bruges til menuer der skal loope indtil syntax er korrekt
            bool exit = false;
            Console.WriteLine("Velkommen til bankens program.");
            Console.WriteLine("For at starte skal du oprette en konto.");
            Console.ReadKey();
            Console.Clear();
            string navn = "";
            int balance;
            //Loop indtil exit er true
            while (exit == false)
            {

                if (navn != "") { Console.Clear(); }
                Console.WriteLine("Indtast navn:");
                navn = Console.ReadLine();
                Console.Clear();
                while (exit == false && navn != "")
                {
                    Console.WriteLine("Indtast din nuværende balance:");
                    try
                    {
                        balance = Convert.ToInt32(Console.ReadLine());
                        p = new BankKonto(navn, balance);
                        Console.Clear();
                        Console.WriteLine("Ny konto var oprettet under oplysningerne:");
                        Console.WriteLine("Navn: " + p.Ejer);
                        Console.WriteLine("Balance: " + p.Balance);
                        Console.WriteLine("Kontonummer: " + p.Nummer);
                        Console.WriteLine();
                        Console.WriteLine("Tryk en tast for at komme til hovedmenuen.");
                        Console.ReadKey();
                        Console.Clear();
                        exit = true;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Fejl! Du skal indtaste et nummer over 0!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 0);
                    }
                }
                if (navn == "")
                {
                    Console.SetCursorPosition(0, 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Fejl! Du skal skrive et navn!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                }
            }
            exit = false;
            while (exit == false)
            {
                Console.WriteLine("[1] For at hæve penge");
                Console.WriteLine("[2] For at indsætte penge");
                Console.WriteLine("[3] For at tjekke balance");
                Console.WriteLine("[4] Tjek transaktioner");
                Console.WriteLine();
                Console.WriteLine("[e] For lukke programmet");
                Console.SetCursorPosition(0, 4);
                string key = Convert.ToString(Console.ReadKey().KeyChar);
                Console.Clear();
                string note;
                int beløb;
                switch(key)
                {
                    case "1":
                        {
                            while (exit == false)
                            {
                                Console.WriteLine("Indtast note til hævning:");
                                note = Convert.ToString(Console.ReadLine());
                                Console.Clear();
                                while (exit == false)
                                {
                                    Console.WriteLine("Indtast beløb:");
                                    try
                                    {
                                        string Read = Console.ReadLine().ToLower();
                                        if (Read == "exit") 
                                        { 
                                            exit = true; 
                                            break; 
                                        }
                                        beløb = Convert.ToInt32(Read);
                                        p.MakeWithdrawal(beløb, DateTime.Now, note);
                                        Console.Clear();
                                        Console.WriteLine("Hævning gemt");
                                        Console.WriteLine();
                                        Console.WriteLine("Tryk en tast for at komme tilbage til hovedmenuen.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        exit = true;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Fejl! Du har enten skrevet et ugyldigt nummer eller du har ikke nok penge på kontoen! (Skriv exit for at komme ud)");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(0, 1);
                                        Console.Write("                                      ");
                                        Console.SetCursorPosition(0, 0);
                                    }
                                }
                                Console.Clear();
                            }
                            exit = false;
                            break;
                        }
                    case "2":
                        {
                            while (exit == false)
                            {
                                Console.WriteLine("Indtast note af indbetaling:");
                                note = Convert.ToString(Console.ReadLine());
                                Console.Clear();
                                while (exit == false)
                                {
                                    Console.WriteLine("Indtast beløb:");
                                    try
                                    {
                                        beløb = Convert.ToInt32(Console.ReadLine());
                                        p.MakeDeposit(beløb, DateTime.Now, note);
                                        Console.Clear();
                                        Console.WriteLine("Indbetaling gemt");
                                        Console.WriteLine();
                                        Console.WriteLine("Tryk en tast for at komme tilbage til hovedmenuen.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        exit = true;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Fejl! Du skal indtaste et nummer over 0!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(0, 1);
                                        Console.Write("                                      ");
                                        Console.SetCursorPosition(0, 0);
                                    }
                                }
                            }
                            exit = false;
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Kontonummer {0} har på nuværende tidspunkt {1} kr på sig", p.Nummer, p.Balance);
                            Console.WriteLine();
                            Console.WriteLine("Tryk en tast for at komme tilbage til hovedmenuen.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Dato:\t\tBeløb:\tBalance: Note:");
                            decimal transbeløb = 0;
                            foreach (var item in p.allTransactions)
                            {
                                transbeløb += item.Beløb;
                                Console.WriteLine($"{item.Dato.ToShortDateString()}\t{item.Beløb}\t{transbeløb}\t{item.Noter}");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Tryk en tast for at komme tilbage til hovedmenuen.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case "e":
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            Console.SetCursorPosition(0, 6);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Fejl! Du skal taste en gyldig tast!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(0, 0);
                            break;
                        }
                }
            }
        }
    }
}
