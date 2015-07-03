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
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Change the way of printing type p");
            Console.WriteLine("Change the checking web-site type w");
            Console.WriteLine("Change the checking attempts type a");
            Console.WriteLine("To check web-site type c");
            Console.WriteLine("For exit type e");
            string result =Console.ReadLine();
            Console.WriteLine("--------------------------------------");
            return result;
        }
    }
}
