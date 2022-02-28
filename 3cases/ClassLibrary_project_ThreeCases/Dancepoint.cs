using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_project_ThreeCases
{
    public class Dancepoint
    {
        public string Navn { get; }
        public int Points { get; }

        public Dancepoint(string navn, int points) //constructor
        {
            this.Navn = navn;
            this.Points = points;
        }

        public static Dancepoint operator +(Dancepoint object1, Dancepoint object2) //+ operator overload
        {
            Dancepoint object3 = new Dancepoint($"Dance par: {object1.Navn} & {object2.Navn}", object1.Points + object2.Points);
            return object3;
        }
    }
}



