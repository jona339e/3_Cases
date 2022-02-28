using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_project_ThreeCases
{
    public class Football
    {
        public string Afleveringer(int x, string y)
        {
            string udmelding = string.Empty;
            y = y.ToUpper();
            if (y == "MÅL")
            {
                udmelding = "Olé olé olé";
                return udmelding;
            }
            else if (x <= 1 && y != "MÅL")
            {
                udmelding = "Shh";
                return udmelding;
            }
            else if (x > 1 && x <= 9 && y != "MÅL")
            {
                for (int i = 0; i < x; i++)
                {
                    udmelding += "Huh! ";
                }
                return udmelding;
            }
            else if (x > 9 && y != "MÅL")
            {
                udmelding = "High Five - Jubel!!!";
                return udmelding;
            }
            else
            {
                udmelding = "Indtastede resultater er ikke godkendt!";
                return udmelding;
            }
        }
    }
}