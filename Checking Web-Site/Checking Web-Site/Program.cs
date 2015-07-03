using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class Program
    {
        static void Main(string[] args)
        {
            iocInit();

            var check = IoC.Get<WebSiteStatus>();
            string userInput;
            do
            {
                userInput = Menu.ShowMenu();
                switch (userInput)
                {
                    case "w":
                        check.ChangeWebSite();
                        break;
                    case "a":
                        check.ChangeAttempts();
                        break;
                    case "p":
                        iocChange();
                        break;
                    case "c":
                        check = IoC.Get<WebSiteStatus>();
                        check.CheckStatus();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (userInput != "e");

            check = IoC.Get<WebSiteStatus>();

            check.CheckStatus();
            Console.ReadLine();
        }

        private static void iocInit()
        {
            IoC.Init((kernel) =>
            {
                kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope();// default
            });
        }
        public static void iocChange()
        {
            Console.WriteLine("To print log to console type c");
            Console.WriteLine("To print log to file type f");
            Console.WriteLine("To print log both ways type b");
            IoC.Reset();
            IoC.Init((kernel) =>
            {
                switch (Console.ReadLine())
                {
                    case "c":
                        kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope();
                        break;
                    case "f":
                        kernel.Bind<IPrint>().To<PrintToFile>().InTransientScope();
                        break;
                    case "b":
                        kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope();
                        kernel.Bind<IPrint>().To<PrintToFile>().InTransientScope();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            });
        }
    }
}
