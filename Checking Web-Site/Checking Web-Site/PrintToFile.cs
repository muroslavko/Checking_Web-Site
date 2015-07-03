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
        private StreamWriter _file;

        public PrintToFile()
        {
            _file = new StreamWriter("1.txt");
        }
        public void Print(string s)
        {
            _file.WriteLine(s);
        }
    }
}
