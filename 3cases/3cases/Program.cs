using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_project_ThreeCases;

namespace Program1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region variables
            int aflevering, point1, point2;
            string mål, danserNavn1, danserNavn2, psw, bruger, switchSwitcher;
            string path = @"User.txt";
            bool end = false;
            bool loginTrue = false;
            bool parsed = false;
            ValidatePassword validatePassword = new ValidatePassword();
            ValidateUser validateUser = new ValidateUser();
            Football football = new Football();
            #endregion


            #region Main Kode
            if (File.Exists(path) == false) // checker om fil med brugerdata findes
            {
                do //opretter bruger hvis ingen bruger findes, dette gøres i et loop indtil password kriterierne er opfyldt.
                {
                    Console.WriteLine("Der er ingen brugere endnu.");
                    Console.WriteLine("Opret Bruger.");
                    Console.WriteLine("---------------------------");
                    Console.Write("Indtast dit Brugernavn: ");
                    bruger = Console.ReadLine();
                    Console.Write("Indtast dit Password: ");
                    psw = Console.ReadLine();

                    if (!string.IsNullOrEmpty(validatePassword.Validate(bruger, psw)))
                    {
                        Console.WriteLine(validatePassword.Validate(bruger, psw));
                    }
                    else
                    {
                        Console.WriteLine("Dit Brugernavn og Password er Godkendt");
                        validateUser.LoginUser();
                    }
                } while (!string.IsNullOrEmpty(validatePassword.Validate(bruger, psw)));
            }
            else
            {
                do
                {
                    Console.WriteLine("-------Velkommen-------");
                    Console.Write("Indtast dit Brugernavn: ");
                    bruger = Console.ReadLine();
                    Console.Write("Indtast dit Password: ");
                    psw = Console.ReadLine();
                    if (!string.IsNullOrEmpty(validateUser.Login(bruger, psw)))
                    {
                        Console.WriteLine(validateUser.Login(bruger, psw));
                    }
                    else
                    {
                        loginTrue = true;
                        validateUser.LoginUser();
                    }
                } while (loginTrue == false); //logger bruger ind hvis der er en bruger
            }
            if (loginTrue == true || string.IsNullOrEmpty(validatePassword.Validate(bruger, psw)))
            //hvis man har logget ind eller oprettet en bruger vil man starte efterfølgende
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Hvad vil du?");
                    Console.WriteLine("1. Ændre Password og Brugernavn");
                    Console.WriteLine("2. Benytte Fodbold program");
                    Console.WriteLine("3. Benytte Danse program");
                    Console.WriteLine("4. Afslutte");
                    switchSwitcher = Console.ReadLine();
                    switch (switchSwitcher) //Switch der bruges som menu, her kan man vælge hvilket program der skal køres,
                                            //samt ændre bruger/password eller afslutte
                    {
                        case "1": // Køre metode der ændre bruger og password
                            {
                                Console.Clear();
                                Console.Write("Indtast dit nye Brugernavn: ");
                                bruger = Console.ReadLine();
                                Console.Write("Indtast dit nye Password: ");
                                psw = Console.ReadLine();
                                if (!string.IsNullOrEmpty(validatePassword.Validate(bruger, psw)))
                                {
                                    Console.WriteLine(validatePassword.Validate(bruger, psw));
                                }
                                else
                                {
                                    Console.WriteLine("Dit Brugernavn og Password er nu blevet ændret!");
                                }
                                Console.ReadKey();
                                break;
                            }
                        case "2": // Kører fodbold program
                            {
                                Console.Clear();
                                Console.WriteLine("Indtast hvor mange afleveringer der har været! (I heltal)");
                                do
                                {

                                    bool succes = Int32.TryParse(Console.ReadLine(), out int afleveringer);
                                    aflevering = afleveringer;

                                if (succes)
                                {

                                    parsed = true;

                                }
                                else
                                {

                                    Console.Clear();
                                    Console.WriteLine("Fejl I indtastning, prøv igen.");
                                    Console.WriteLine("Indtast hvor mange afleveringer der har været! (I heltal)");

                                    }
                                } while (parsed == false);

                                Console.WriteLine("Skriv 'Mål' hvis der har været mål");
                                mål = Console.ReadLine();
                                Console.WriteLine(football.Afleveringer(aflevering, mål));
                                Console.ReadKey();
                                break;
                            }
                        case "3": // Kører danse program
                            {
                                Console.Clear();
                                Console.Write("Indtast navn på første danser: ");
                                danserNavn1 = Console.ReadLine();
                                parsed = false;

                                do
                                {
                                    bool succes = Int32.TryParse(Console.ReadLine(), out int point_parse);
                                    point1 = point_parse;
                                    if (succes)
                                    {
                                        parsed = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Fejl I indtastning, prøv igen.");
                                        Console.WriteLine("Indtast point for {0}: ", danserNavn1);
                                    }

                                } while (parsed == false);

                                Console.Write("Indtast navn på anden danser: ");
                                danserNavn2 = Console.ReadLine();

                                parsed = false;

                                do
                                {
                                    bool succes = Int32.TryParse(Console.ReadLine(), out int point_parse);
                                    point2 = point_parse;
                                    if (succes)
                                    {
                                        parsed = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Fejl I indtastning, prøv igen.");
                                        Console.WriteLine("Indtast point for {0}: ", danserNavn2);
                                    }

                                } while (parsed == false);


                                Dancepoint navn1 = new Dancepoint(danserNavn1, point1);
                                Dancepoint navn2 = new Dancepoint(danserNavn2, point2);
                                Dancepoint obj3 = navn1 + navn2;
                                Console.WriteLine(obj3.Navn + " Points:" + obj3.Points);
                                Console.ReadKey();
                                break;
                            }
                        case "4": //afslutter program
                            {
                                Console.Clear();
                                Console.WriteLine("Program Afsluttes");
                                System.Threading.Thread.Sleep(2000);
                                end = true;
                                Environment.Exit(0);
                                break;
                            }
                        default: //fejlmeddelelse hvis man indtaster noget forkert.
                            {
                                Console.Clear();
                                Console.WriteLine("Ugyldigt input. Prøv Igen");
                                Console.ReadKey();
                                break;
                            }
                    }
                } while (end == false);
            }
            else
            {
                Console.WriteLine("fatal fejl, program afsluttes.");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
            #endregion
        }
    }
}