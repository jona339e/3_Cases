using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_project_ThreeCases
{
    public class Dancepoint
    {
        private string navn;
        private int points;

        public Dancepoint(string navn, int points) //constructor
        {
            this.navn = navn;
            this.points = points;
        }

        public static Dancepoint operator +(Dancepoint navn1, Dancepoint navn2) //+ operator overload
        {
            Dancepoint dancepoint = new Dancepoint(navn1.navn + " & " + navn2.navn, navn1.points + navn2.points);
            return dancepoint;
        }

        public void udskriv() //bestemmer hvordan mine objekter udskrives
        {
            Console.WriteLine(navn + " " + points);
        }
    }
}



