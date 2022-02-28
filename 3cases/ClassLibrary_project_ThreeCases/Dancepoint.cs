using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_project_ThreeCases
{
    public class Dancepoint
    {
        public string DansePoint(string navn1, string navn2) //tager to string-inputs og returnere en string hvor der star "input1 & input2 "
        {
            string navn = navn1 + " & " + navn2 + " ";
            return navn;
        }
        public int DansePoint(int point1, int point2) //tager to int-inputs og returnere de to inputs lagt sammen.
        {
            int point = point1 + point2;
            return point;
        }
    }
}
