using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SchereSteinPapier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int SchereChaunsen, SteinChaunsen, PapierChaunsen, ZufallsWahl, ComputerPunkte, SpielerPunkte, Runde, ScherenZähler, SteinZähler, PapierZähler, MaximalPunkte;
            string SpielerWahl, SpielerWahlerString, ComputerWahl, MaximalPunkteString;
            bool Zähler;
            Random Zufall = new Random();
            while (true)
            {
                SchereChaunsen = 300;
                SteinChaunsen = 300;
                PapierChaunsen = 300;
                Runde = 1;
                ComputerPunkte = 0;
                SpielerPunkte = 0;
                ScherenZähler = 0;
                SteinZähler = 0;
                PapierZähler = 0;
                Zähler = false;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Maximalpunkte: ");
                    Console.CursorVisible = true;
                    MaximalPunkteString = Console.ReadLine();
                    Console.CursorVisible = false;
                    int.TryParse(MaximalPunkteString, out MaximalPunkte);
                } while (MaximalPunkte <= 0);
                do
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("          WÄHLE!\n");
                    Console.WriteLine("SCHERE   -> [1]                         Runde " + Runde);
                    Console.WriteLine("STEIN    -> [2]                         Ihre Punkte = " + SpielerPunkte);
                    Console.WriteLine("PAPIER   -> [3]                         Computers Punkte = " + ComputerPunkte);
                    Console.WriteLine("Aufgeben -> [9]                         Maximal Punkte = " + MaximalPunkte);
                    /*
                    Console.WriteLine("\nSchere Chaunsen = " + SchereChaunsen);
                    Console.WriteLine("Stein Chaunsen = " + SteinChaunsen);
                    Console.WriteLine("Papier Chaunsen = " + PapierChaunsen);
                    */
                    SpielerWahlerString = "FEHLER";
                    ComputerWahl = "FEHLER";
                    SpielerWahl = Console.ReadKey(true).KeyChar.ToString();
                    if (SpielerWahl == "9")
                    {
                        break;
                    }
                    if (SpielerWahl != "1" && SpielerWahl != "2" && SpielerWahl != "3")
                    {
                        Console.SetCursorPosition(12, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[1]");
                        Console.SetCursorPosition(12, 3);
                        Console.Write("[2]");
                        Console.SetCursorPosition(12, 4);
                        Console.Write("[3]");
                        Console.SetCursorPosition(12, 5);
                        Console.Write("[9]");
                        Thread.Sleep(30);
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (SpielerWahl == "1" || SpielerWahl == "2" || SpielerWahl == "3")
                    {
                        if (SpielerWahl == "1")
                        {
                            ScherenZähler++;
                            SpielerWahlerString = "SCHERE"; ;
                        }
                        if (SpielerWahl == "2")
                        {
                            SteinZähler++;
                            SpielerWahlerString = "STEIN";
                        }
                        if (SpielerWahl == "3")
                        {
                            PapierZähler++;
                            SpielerWahlerString = "PAPIER";
                        }
                        if (ScherenZähler > 2)
                        {
                            if (SpielerWahlerString == "SCHERE")
                            {
                                Zähler = true;
                                ComputerWahl = "STEIN";
                            }
                            else
                            {
                                Zähler = false;
                                ScherenZähler = 0;
                            }
                        }
                        else if (SteinZähler > 2)
                        {
                            if (SpielerWahlerString == "STEIN")
                            {
                                Zähler = true;
                                ComputerWahl = "PAPIER";
                            }
                            else
                            {
                                Zähler = false;
                                SteinZähler = 0;
                            }
                        }
                        else if (PapierZähler > 2)
                        {
                            if (SpielerWahlerString == "PAPIER")
                            {
                                Zähler = true;
                                ComputerWahl = "SCHERE";
                            }
                            else
                            {
                                Zähler = false;
                                PapierZähler = 0;
                            }
                        }
                        if (Zähler == false)
                        {
                            if (SchereChaunsen > SteinChaunsen)
                            {
                                if (SchereChaunsen > PapierChaunsen)
                                {
                                    ComputerWahl = "SCHERE";
                                }
                                else if (SchereChaunsen == PapierChaunsen)
                                {
                                    ZufallsWahl = Zufall.Next(1, 100);
                                    if (ZufallsWahl <= 50)
                                    {
                                        ComputerWahl = "SCHERE";
                                    }
                                    else
                                    {
                                        ComputerWahl = "PAPIER";
                                    }
                                }
                                else
                                {
                                    ComputerWahl = "PAPIER";
                                }
                            }
                            else if (SchereChaunsen == SteinChaunsen)
                            {
                                if (SchereChaunsen > PapierChaunsen)
                                {
                                    ZufallsWahl = Zufall.Next(1, 100);
                                    if (ZufallsWahl <= 50)
                                    {
                                        ComputerWahl = "SCHERE";
                                    }
                                    else
                                    {
                                        ComputerWahl = "STEIN"; ;
                                    }
                                }
                                else if (SchereChaunsen == PapierChaunsen)
                                {
                                    ZufallsWahl = Zufall.Next(1, 150);
                                    if (ZufallsWahl <= 50)
                                    {
                                        ComputerWahl = "SCHERE";
                                    }
                                    if (ZufallsWahl > 50 && ZufallsWahl <= 100)
                                    {
                                        ComputerWahl = "STEIN"; ;
                                    }
                                    if (ZufallsWahl > 100)
                                    {
                                        ComputerWahl = "PAPIER";
                                    }
                                }
                                else
                                {
                                    ComputerWahl = "PAPIER";
                                }
                            }
                            else
                            {
                                if (SteinChaunsen > PapierChaunsen)
                                {
                                    ComputerWahl = "STEIN"; ;
                                }
                                else if (SteinChaunsen == PapierChaunsen)
                                {
                                    ZufallsWahl = Zufall.Next(1, 100);
                                    if (ZufallsWahl <= 50)
                                    {
                                        ComputerWahl = "STEIN"; ;
                                    }
                                    else
                                    {
                                        ComputerWahl = "PAPIER";
                                    }
                                }
                                else
                                {
                                    ComputerWahl = "PAPIER";
                                }
                            }
                        }
                        Console.Clear();
                        if (SpielerWahlerString == "FEHLER" || ComputerWahl == "FEHLER")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("          FEHLER!");
                            Console.WriteLine("\nEin Fehler ist passiert.");
                            Console.WriteLine("Probieren Sie es erneut.");
                            Console.WriteLine("Hoffentlich funktioniert es ,dass nächste Mal.");
                        }
                        else
                        {
                            if (SpielerWahlerString == ComputerWahl)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("          UNENTSCHIEDEN!");
                            }
                            else
                            {
                                if (SpielerWahlerString == "SCHERE")
                                {
                                    if (ComputerWahl == "STEIN")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("          VERLUST!");
                                        ComputerPunkte++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("          SIEG!");
                                        SpielerPunkte++;
                                    }
                                }
                                if (SpielerWahlerString == "STEIN")
                                {
                                    if (ComputerWahl == "PAPIER")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("          VERLUST!");
                                        ComputerPunkte++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("          SIEG!");
                                        SpielerPunkte++;
                                    }
                                }
                                if (SpielerWahlerString == "PAPIER")
                                {
                                    if (ComputerWahl == "SCHERE")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("          VERLUST!");
                                        ComputerPunkte++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("          SIEG!");
                                        SpielerPunkte++;
                                    }
                                }
                            }
                            Console.WriteLine("\nIhre Wahl      = " + SpielerWahlerString);
                            Console.WriteLine("Computers Wahl = " + ComputerWahl);
                            Console.SetCursorPosition(40, 2);
                            Console.Write("Runde " + Runde);
                            Console.SetCursorPosition(40, 3);
                            Console.WriteLine("Ihre Punkte = " + SpielerPunkte);
                            Console.WriteLine("                                        Computers Punkte = " + ComputerPunkte);
                            Console.WriteLine("                                        Maximal Punkte = " + MaximalPunkte);

                        }
                        Console.ReadKey(true);
                        Runde++;
                    }
                    if (SpielerWahl == "1")
                    {
                        SchereChaunsen = SchereChaunsen - (SchereChaunsen / 3);
                        SteinChaunsen = SteinChaunsen + (SteinChaunsen / 3);
                        PapierChaunsen = PapierChaunsen + (PapierChaunsen / 3);
                    }
                    if (SpielerWahl == "2")
                    {
                        SteinChaunsen = SteinChaunsen - (SteinChaunsen / 3);
                        SchereChaunsen = SchereChaunsen + (SchereChaunsen / 3);
                        PapierChaunsen = PapierChaunsen + (PapierChaunsen / 3);
                    }
                    if (SpielerWahl == "3")
                    {
                        PapierChaunsen = PapierChaunsen - (PapierChaunsen / 3);
                        SchereChaunsen = SchereChaunsen + (SchereChaunsen / 3);
                        SteinChaunsen = SteinChaunsen + (SteinChaunsen / 3);
                    }
                } while (SpielerPunkte < MaximalPunkte && ComputerPunkte < MaximalPunkte);
                Runde--;
                Console.Clear();
                if (SpielerWahl == "9")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("          DER COMPUTER HAT GEWONNEN!\n");
                }
                else if (SpielerPunkte > ComputerPunkte)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("          DU HAST GEWONNEN!\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("          DER COMPUTER HAT GEWONNEN!\n");
                }
                Console.WriteLine("In " + Runde + " Runden.");
                Console.WriteLine("Ihre Punkte = " + SpielerPunkte);
                Console.WriteLine("Computers Punkte = " + ComputerPunkte);
                Console.WriteLine("Maximal Punkte = " + MaximalPunkte);
                Console.ReadKey(true);
            }
        }
    }
}
