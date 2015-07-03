using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class PrintToConsole : IPrint
    {
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
