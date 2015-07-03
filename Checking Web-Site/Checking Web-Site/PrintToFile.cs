using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class PrintToFile : IPrint
    {
        public void Print(string s)
        {
            using (StreamWriter file = new StreamWriter("1.txt"))
            {
                file.WriteLine(s);
            }
        }
    }
}
