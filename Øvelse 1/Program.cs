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
                Console.WriteLine("Indtast navn:");
                navn = Console.ReadLine();
                Console.Clear();
                //Går videre hvis navn er udfyldt
                while (exit == false && navn != "")
                {
                    Console.WriteLine("Indtast din nuværende balance:");
                    try
                    {
                        //Konvertere input til int for at tjekke at det faktisk er et tal
                        balance = Convert.ToInt32(Console.ReadLine());
                        //Giver objektet p de oplysninger som vores bruger har udfyldt
                        p = new BankKonto(navn, balance);
                        Console.Clear();
                        //Udskriver ny oprettet kontos oplysninger
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
                        //Fejl hvis saldo ikk er et tal eller er et tal under 0
                        Console.Clear();
                        Console.SetCursorPosition(0, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Fejl! Du skal indtaste et nummer over 0!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 0);
                    }
                }
                //Fejl hvis navn ikk er udfyldt
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
                //Hovedmenu
                Console.WriteLine("[1] For at hæve penge");
                Console.WriteLine("[2] For at indsætte penge");
                Console.WriteLine("[3] For at tjekke balance");
                Console.WriteLine("[4] Tjek transaktioner");
                Console.WriteLine();
                Console.WriteLine("[e] For lukke programmet");
                Console.SetCursorPosition(0, 4);
                //Readkey der gemmer trykkede tast i en string
                string key = Convert.ToString(Console.ReadKey().KeyChar);
                Console.Clear();
                string note;
                int beløb;
                //Switch case der bruges til valg af undermenuer via den trykkede knap
                switch(key)
                {
                    case "1":
                        {
                            //Case 1 er hævning
                            while (exit == false)
                            {
                                Console.WriteLine("Indtast note til hævning:");
                                note = Convert.ToString(Console.ReadLine());
                                //Indtastet tekst bliver sat til string note, behøver ikke udfyldes
                                Console.Clear();
                                while (exit == false)
                                {
                                    Console.WriteLine("Indtast beløb:");
                                    try
                                    {
                                        //Opsat en udvej hvis man skriver exit, bruges hvis man foreksempel ikke har nok at hæve fra
                                        string Read = Console.ReadLine().ToLower();
                                        if (Read == "exit") 
                                        { 
                                            exit = true; 
                                            break; 
                                        }
                                        //Konverterer input til int
                                        beløb = Convert.ToInt32(Read);
                                        //Laver transaktion
                                        p.MakeWithdrawal(beløb, DateTime.Now, note);
                                        Console.Clear();
                                        //Bekræftelse af hævning
                                        Console.WriteLine("Hævning gemt");
                                        Console.WriteLine();
                                        Console.WriteLine("Tryk en tast for at komme tilbage til hovedmenuen.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        exit = true;
                                    }
                                    catch
                                    {
                                        //Fejl hvis input er ugyldigt eller saldoen er for lav
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Fejl! Du har enten skrevet et ugyldigt nummer eller du har ikke nok penge på kontoen! (Skriv exit for at komme ud)");
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
                    case "2":
                        {
                            //Case 2 er indbetaling
                            while (exit == false)
                            {
                                //Fungere præcis som case 1
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
                            //Case 3 af tjek af saldo
                            //Udskriver kontonummer samt saldo
                            Console.WriteLine("Kontonummer {0} har på nuværende tidspunkt {1} kr på sig", p.Nummer, p.Balance);
                            Console.WriteLine();
                            Console.WriteLine("Tryk en tast for at komme tilbage til hovedmenuen.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case "4":
                        {
                            //Case 4 er transaktion historien
                            Console.WriteLine("Dato:\t\tBeløb:\tBalance: Note:");
                            //transbeløb bruges til at beregne bruges saldo efter hver transaktion
                            decimal transbeløb = 0;
                            foreach (var item in p.allTransactions)
                            {
                                transbeløb += item.Beløb;
                                //Udskriver transaktions information samt udregnet saldo fra daværende tidspunkt
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
                            //Case e lukker programmet
                            exit = true;
                            break;
                        }
                    default:
                        {
                            //Hvis en anden tast bliver trykket udskrives fejl
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
