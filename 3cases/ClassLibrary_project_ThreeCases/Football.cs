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
            else if (x < 1)
            {
                udmelding = "Shh";
                return udmelding;
            }
           else if (x > 0 && x <= 9)
            {
                for (int i = 0; i < x; i++)
                {
                    udmelding += "Huh! ";
                }
                return udmelding;
            }
            else
            {
                udmelding = "High Five - Jubel!!!";

                return udmelding;
            }
        }
    }
}