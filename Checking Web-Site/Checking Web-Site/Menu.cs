using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    public static class Menu
    {
        public static string ShowMenu()
        {
            Console.WriteLine("Change the way of printing type p");
            Console.WriteLine("Change the checking web-site type w");
            Console.WriteLine("For exit type e");
            string result =Console.ReadLine();
            return result;
        }
    }
}
