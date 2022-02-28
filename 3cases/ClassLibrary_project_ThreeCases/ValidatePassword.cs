using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_project_ThreeCases
{
    public class ValidatePassword
    {
        public string Validate(string bruger, string password) // Kalder nedenstående metoder til at validere omg passwordet lever op til kravene
        {
            string errorMessegeÍfSpace = ContainsSpace(password);
            string errorMessageÍfLength = PasswordLength(password);
            string errorMessageÍfUpper = UpperCaseLetter(password);
            string errorMessageÍfLower = LowerCaseLetter(password);
            string errorMessageÍfSpecial = SpecialLetter(password);
            string errorMessageÍfStart = StartsWithDigit(password);
            string errorMessageÍfEnds = EndsWithDigit(password);
            string errorMessageÍfSame = UserCheckPsw(bruger, password);

            if (!string.IsNullOrEmpty(errorMessegeÍfSpace)) //Hvis input ikke er null eller tom, vil input returneres. Input er kun tom hvis der ikke er nogen fejl.
            {
                return errorMessegeÍfSpace;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfLength))
            {
                return errorMessageÍfLength;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfUpper))
            {
                return errorMessageÍfUpper;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfLower))
            {
                return errorMessageÍfLower;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfSpecial))
            {
                return errorMessageÍfSpecial;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfStart))
            {
                return errorMessageÍfStart;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfEnds))
            {
                return errorMessageÍfEnds;
            }
            else if (!string.IsNullOrEmpty(errorMessageÍfSame))
            {
                return errorMessageÍfSame;
            }
            else // hvis ingen af ovenstående metoder returnere noget,
                 // vil WriteToFile blive eksekveret. Her bliver mit brugernavn og password skrevet til en tekstfil på linje 1 og 2.
            {
                WriteToFile(bruger, password);
                return "";
            }            
        } 
        private string UserCheckPsw(string bruger, string password) // Checker om brugernavn og password er det samme og giver en fejl hvis det er.
        {
            if (bruger.ToLower() != password.ToLower())
            {
                return "";
            }
            else
            {
                return "Brugernavn og Password må ikke være det samme";
            }
        }
        private string ContainsSpace(string password) // Checker om der er mellemrum i mit password, fejl hvis der er.
        {
            if (password.Contains(" ") == false)
            {
                return "";
            }
            else
            {
                return "Du Må ikke have mellemrum i dit password";
            }
        }
        private string PasswordLength(string password) // Checker om der er min 12 tegn i mit password, fejl hvis der ikke er.
        {
            if (password.Length >= 12)
            {
                return "";
            }
            else
            {
                return "Dit password skal være på mindst 12 tegn";
            }
        }
        private string UpperCaseLetter(string password) // Checker om der findes et uppercase character i mit password, fejl hvis der ikke er.
        {
            foreach (char upper in password)
            {
                if (Char.IsUpper(upper))
                {
                    return "";
                }
            }
                return "Dit password skal indeholde et stort bogstav";
        }
        private string LowerCaseLetter(string password) // Checker om der findes et lowercase character i mit password, fejl hvis der ikke er.
        {
            {
                foreach (char lower in password)
                {
                    if (Char.IsUpper(lower))
                    {
                        return "";
                    }
                }
                return "Dit password skal indeholde et lille bogstav";
            }
        }
        private string SpecialLetter(string password) // Checker om der findes et specialtegn i mit password, fejl hvis der ikke er.
        {
                foreach (char special in password)
                {
                    if (!Char.IsLetterOrDigit(special))
                    {
                        return "";
                    }
                }
                return "Dit password skal indeholde et special-tegn";
        }
        private string StartsWithDigit(string password) // Checker om mit password starter med et tal, fejl hvis det gør.
        {
            if (Char.IsDigit(password[0]))
            {
                return "Dit password må ikke starte med et tal";
            }
            else
            {
                return "";
            }
        }
        private string EndsWithDigit(string password) // Checker om mit password slutter med et tal, fejl hvis det gør.
        {
            if (Char.IsDigit(password[password.Length - 1]))
            {
                return "Dit password må ikke slutte med et tal";
            }
            else
            {
                return "";
            }
        }
        private void WriteToFile(string bruger, string password) // Skriver mit brugernavn og password til en tekstfil.
        {
            string[] user = { bruger, password };
            string path = @"User.txt";

            File.WriteAllLines(path, user);
        }
    }
    public class ValidateUser
    {
        public string Login(string bruger, string password) // Læser en txt fil, hvor bruger og password findes.
                                                            // Hvis disse stemmer overens med input bliver en tom streng returneret,
                                                            // ellers bliver en fejlmeddelse returneret som streng.
        {
            string path = @"User.txt";
            string[] text = File.ReadAllLines(path);
            if (bruger == text[0] && password == text[1])
            {
                return "";
            }
            else
            {
                return "Dine login oplysninger er forkerte...";
            }
        }
        public void LoginUser() // Får brugeren til at vente i 2 sekunder før næste skærm vises.
        {
            Console.Clear();
            Console.WriteLine("Du bliver nu Logget ind");
            Console.WriteLine("-------------------------------");
            System.Threading.Thread.Sleep(2000);
        }
    }

    //Mathias (instruktør) har skrevet nedenstående kode
    //Data Tranfer object
    public class ValidatePassword_Dto
    {
        //public ValidatePassword_Dto(string errorMesesge)
        //{
        //    ErrorMessege = errorMesesge;
        //}
        public string ErrorMessege { get; set; }
        public bool Succes { get; set; }
    }
    public class ValidatePassword_Udvidet
    {
        public string ValidateUdvidet(string password)
        {
            ValidatePassword_Dto dto = ContainsSpaceUdvidet(password);
            if (!dto.Succes)
            {
                return dto.ErrorMessege;
            }
            return "";
        }
        private ValidatePassword_Dto ContainsSpaceUdvidet(string password)
        {
            //Opretter objektet med navnet dto
            ValidatePassword_Dto dto = new ValidatePassword_Dto();
            if (password.Contains(" "))
            {
                dto.Succes = false;
                dto.ErrorMessege = "Du Må ikke have mellemrum i dit password";
                return dto;
            }
            else
            {
                dto.Succes = true;
                return dto;
            }
        }
    }
}