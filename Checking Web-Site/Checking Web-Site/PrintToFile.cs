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
        public PrintToFile()
        {
            using (StreamWriter file = new StreamWriter("1.txt",false))
            {} 
        }
        public void Print(StringBuilder s)
        {
            using (StreamWriter file = new StreamWriter("1.txt",true))
            {
                file.WriteLine(s);
            }
        }
    }
}
