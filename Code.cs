using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace SchereSteinPapier
{
    using System.Threading;
    using System;

    internal class Program
    {
        static void Main( string[] args )
        {
            int SchereChaunsen, SteinChaunsen, PapierChaunsen, ZufallsWahl = 0, ComputerPunkte, SpielerPunkte, Runde, SchereZähler, SteinZähler, PapierZähler, SchereMinusZähler, SteinMinusZähler, PapierMinusZähler, MaximalPunkte;
            string SpielerWahl, SpielerWahlerString, ComputerWahl, MaximalPunkteString;
            bool Zähler;
            Random Zufall = new Random();
            while( true )
            {
                SchereChaunsen = 300;
                SteinChaunsen = 300;
                PapierChaunsen = 300;
                Runde = 1;
                ComputerPunkte = 0;
                SpielerPunkte = 0;
                SchereZähler = 0;
                SteinZähler = 0;
                PapierZähler = 0;
                SchereMinusZähler = 0;
                SteinMinusZähler = 0;
                PapierMinusZähler = 0;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write( "Maximalpunkte: " );
                    Console.CursorVisible = true;
                    MaximalPunkteString = Console.ReadLine();
                    Console.CursorVisible = false;
                    int.TryParse( MaximalPunkteString, out MaximalPunkte );
                } while( MaximalPunkte <= 0 );
                do
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine( "          WÄHLE!\n" );
                    Console.WriteLine( "SCHERE   -> [1]                         Runde " + Runde );
                    Console.WriteLine( "STEIN    -> [2]                         Ihre Punkte = " + SpielerPunkte );
                    Console.WriteLine( "PAPIER   -> [3]                         Computers Punkte = " + ComputerPunkte );
                    Console.WriteLine( "Aufgeben -> [9]                         Maximal Punkte = " + MaximalPunkte );
                    /*
                    Console.WriteLine("\n         DEBUG: ");
                    Console.WriteLine("     Schere Chaunsen = " + SchereChaunsen);
                    Console.WriteLine("     Stein Chaunsen = " + SteinChaunsen);
                    Console.WriteLine("     Papier Chaunsen = " + PapierChaunsen);
                    Console.WriteLine("     Scheren Wahl Aufzählung = " + SchereZähler);
                    Console.WriteLine("     Stein Wahl Aufzählung = " + SteinZähler);
                    Console.WriteLine("     Papier Wahl Aufzählung = " + PapierZähler);
                    Console.WriteLine("     Scheren Auslassungs Aufzählung = " + SchereMinusZähler);
                    Console.WriteLine("     Stein Auslassungs Aufzählung = " + SteinMinusZähler);
                    Console.WriteLine("     Papier Auslassungs Aufzählung = " + PapierMinusZähler);
                    */
                    SpielerWahlerString = "FEHLER";
                    ComputerWahl = "FEHLER";
                    SpielerWahl = Console.ReadKey( true ).KeyChar.ToString();
                    if( SpielerWahl == "9" )
                    {
                        break;
                    }
                    if( SpielerWahl != "1" && SpielerWahl != "2" && SpielerWahl != "3" )
                    {
                        Console.SetCursorPosition( 12, 2 );
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write( "[1]" );
                        Console.SetCursorPosition( 12, 3 );
                        Console.Write( "[2]" );
                        Console.SetCursorPosition( 12, 4 );
                        Console.Write( "[3]" );
                        Console.SetCursorPosition( 12, 5 );
                        Console.Write( "[9]" );
                        Thread.Sleep( 30 );
                        Console.SetCursorPosition( 0, 0 );
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if( SpielerWahl == "1" || SpielerWahl == "2" || SpielerWahl == "3" )
                    {
                        switch( SpielerWahl )
                        {
                            case "1":
                                SpielerWahlerString = "SCHERE";
                                break;
                            case "2":
                                SpielerWahlerString = "STEIN";
                                break;
                            case "3":
                                SpielerWahlerString = "PAPIER";
                                break;
                        }
                        Zähler = false;
                        if( SchereZähler > 1 )
                        {
                            ComputerWahl = "STEIN";
                            Zähler = true;
                        }
                        if( SteinZähler > 1 )
                        {
                            ComputerWahl = "PAPIER";
                            Zähler = true;
                        }
                        if( PapierZähler > 1 )
                        {
                            ComputerWahl = "SCHERE";
                            Zähler = true;
                        }
                        if( Zähler == false )
                        {
                            if( SchereMinusZähler < -2 )
                            {
                                ComputerWahl = SteinPapier( SteinChaunsen, PapierChaunsen, ZufallsWahl, Zufall );
                            }
                            else if( SteinMinusZähler < -2 )
                            {
                                ComputerWahl = ScherePapier( SteinChaunsen, PapierChaunsen, ZufallsWahl, Zufall );
                            }
                            else if( PapierMinusZähler < -2 )
                            {
                                if( SchereChaunsen > SteinChaunsen )
                                {
                                    ComputerWahl = "STEIN";
                                }
                                else if( SchereChaunsen == SteinChaunsen )
                                {
                                    ZufallsWahl = Zufall.Next( 1, 100 );
                                    if( ZufallsWahl <= 50 )
                                    {
                                        ComputerWahl = "STEIN";
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
                            else
                            {
                                if( SchereChaunsen > SteinChaunsen )
                                {
                                    ComputerWahl = ScherePapier( SteinChaunsen, PapierChaunsen, ZufallsWahl, Zufall );
                                }
                                else if( SchereChaunsen == SteinChaunsen )
                                {
                                    if( SchereChaunsen > PapierChaunsen )
                                    {
                                        ZufallsWahl = Zufall.Next( 1, 100 );
                                        if( ZufallsWahl <= 50 )
                                        {
                                            ComputerWahl = "STEIN";
                                        }
                                        else
                                        {
                                            ComputerWahl = "PAPIER";
                                        }
                                    }
                                    else if( SchereChaunsen == PapierChaunsen )
                                    {
                                        ZufallsWahl = Zufall.Next( 1, 150 );
                                        if( ZufallsWahl <= 50 )
                                        {
                                            ComputerWahl = "STEIN";
                                        }
                                        if( ZufallsWahl > 50 && ZufallsWahl <= 100 )
                                        {
                                            ComputerWahl = "PAPIER";
                                        }
                                        if( ZufallsWahl > 100 )
                                        {
                                            ComputerWahl = "SCHERE";
                                        }
                                    }
                                    else
                                    {
                                        ComputerWahl = "SCHERE";
                                    }
                                }
                                else
                                {
                                    ComputerWahl = SteinPapier( SteinChaunsen, PapierChaunsen, ZufallsWahl, Zufall );
                                }
                            }
                        }
                        Console.Clear();
                        if( SpielerWahlerString == "FEHLER" || ComputerWahl == "FEHLER" )
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine( "          FEHLER!" );
                            Console.WriteLine( "\nEin Fehler ist passiert." );
                            Console.WriteLine( "Probieren Sie es erneut." );
                            Console.WriteLine( "Hoffentlich funktioniert es ,dass nächste Mal." );
                        }
                        else
                        {
                            if( SpielerWahlerString == ComputerWahl )
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine( "          UNENTSCHIEDEN!" );
                            }
                            else
                            {
                                if( SpielerWahlerString == "SCHERE" )
                                {
                                    if( ComputerWahl == "STEIN" )
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine( "          VERLUST!" );
                                        ComputerPunkte++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine( "          SIEG!" );
                                        SpielerPunkte++;
                                    }
                                }
                                if( SpielerWahlerString == "STEIN" )
                                {
                                    if( ComputerWahl == "PAPIER" )
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine( "          VERLUST!" );
                                        ComputerPunkte++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine( "          SIEG!" );
                                        SpielerPunkte++;
                                    }
                                }
                                if( SpielerWahlerString == "PAPIER" )
                                {
                                    if( ComputerWahl == "SCHERE" )
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine( "          VERLUST!" );
                                        ComputerPunkte++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine( "          SIEG!" );
                                        SpielerPunkte++;
                                    }
                                }
                            }
                            Console.WriteLine( "\nIhre Wahl      = " + SpielerWahlerString );
                            Console.WriteLine( "Computers Wahl = " + ComputerWahl );
                            Console.SetCursorPosition( 40, 2 );
                            Console.Write( "Runde " + Runde );
                            Console.SetCursorPosition( 40, 3 );
                            Console.WriteLine( "Ihre Punkte = " + SpielerPunkte );
                            Console.WriteLine( "                                        Computers Punkte = " + ComputerPunkte );
                            Console.WriteLine( "                                        Maximal Punkte = " + MaximalPunkte );
                        }
                        Console.ReadKey( true );
                        Runde++;
                    }
                    switch( SpielerWahlerString )
                    {
                        case "SCHERE":
                            SchereChaunsen = SchereChaunsen - (SchereChaunsen / 3);
                            SteinChaunsen = SteinChaunsen + (SteinChaunsen / 6);
                            PapierChaunsen = PapierChaunsen + (PapierChaunsen / 6);
                            SchereZähler++;
                            SteinZähler = 0;
                            PapierZähler = 0;
                            SchereMinusZähler = 0;
                            SteinMinusZähler--;
                            PapierMinusZähler--;
                            break;
                        case "STEIN":
                            SteinChaunsen = SteinChaunsen - (SteinChaunsen / 3);
                            SchereChaunsen = SchereChaunsen + (SchereChaunsen / 6);
                            PapierChaunsen = PapierChaunsen + (PapierChaunsen / 6);
                            SteinZähler++;
                            SchereZähler = 0;
                            PapierZähler = 0;
                            SteinMinusZähler = 0;
                            SchereMinusZähler--;
                            PapierMinusZähler--;
                            break;
                        case "PAPIER":
                            PapierChaunsen = PapierChaunsen - (PapierChaunsen / 3);
                            SchereChaunsen = SchereChaunsen + (SchereChaunsen / 6);
                            SteinChaunsen = SteinChaunsen + (SteinChaunsen / 6);
                            PapierZähler++;
                            SchereZähler = 0;
                            SteinZähler = 0;
                            PapierMinusZähler = 0;
                            SchereMinusZähler--;
                            SteinMinusZähler--;
                            break;
                    }
                } while( SpielerPunkte < MaximalPunkte && ComputerPunkte < MaximalPunkte );
                Runde--;
                Console.Clear();
                if( SpielerWahl == "9" )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "          DER COMPUTER HAT GEWONNEN!\n" );
                }
                else if( SpielerPunkte > ComputerPunkte )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine( "          DU HAST GEWONNEN!\n" );
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "          DER COMPUTER HAT GEWONNEN!\n" );
                }
                Console.WriteLine( "In " + Runde + " Runden." );
                Console.WriteLine( "Ihre Punkte = " + SpielerPunkte );
                Console.WriteLine( "Computers Punkte = " + ComputerPunkte );
                Console.WriteLine( "Maximal Punkte = " + MaximalPunkte );
                Console.ReadKey( true );
            }
        }
        static string SteinPapier( int SteinChaunsen, int PapierChaunsen, int ZufallsWahl, Random Zufall )
        {
            if( SteinChaunsen > PapierChaunsen )
            {
                return "PAPIER";
            }
            else if( SteinChaunsen == PapierChaunsen )
            {
                ZufallsWahl = Zufall.Next( 1, 100 );
                if( ZufallsWahl <= 50 )
                {
                    return "PAPIER";
                }
                else
                {
                    return "SCHERE";
                }
            }
            else
            {
                return "SCHERE";
            }
        }
        static string ScherePapier( int SchereChaunsen, int PapierChaunsen, int ZufallsWahl, Random Zufall )
        {
            if( SchereChaunsen > PapierChaunsen )
            {
                return "STEIN";
            }
            else if( SchereChaunsen == PapierChaunsen )
            {
                ZufallsWahl = Zufall.Next( 1, 100 );
                if( ZufallsWahl <= 50 )
                {
                    return "STEIN";
                }
                else
                {
                    return "SCHERE";
                }
            }
            else
            {
                return "SCHERE";
            }
        }
    }
}
