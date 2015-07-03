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
            iocInit(PrintType.Console);

            var check = IoC.Get<WebSiteStatus>();
            string userInput;
            do
            {
                userInput= Menu.ShowMenu();
                switch (userInput)
                {
                    case "w":
                        check.ChangeWebSite();
                        break;
                    case "p":
                        iocChange();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (userInput == "e");


            //iocInit();

            check = IoC.Get<WebSiteStatus>();

            check.CheckStatus();
            Console.ReadLine();
        }

        private static void iocInit(PrintType a)
        {
            IoC.Reset();
            IoC.Init((kernel) =>
            {
                if (PrintType.Console ==a)
                {
                    kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope();// default
                }
                else if (PrintType.File == a)
                {
                    kernel.Bind<IPrint>().To<PrintToFile>().InTransientScope();
                }
                else
                {
                    kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope();
                    kernel.Bind<IPrint>().To<PrintToFile>().InTransientScope();
                }
            });
        }
        public static void iocChange()
        {
            Console.WriteLine("To print log to console type c");
            Console.WriteLine("To print log to file type f");
            Console.WriteLine("To print log both ways type b");
            switch (Console.ReadLine())
            {
                case "c":
                    iocInit(PrintType.Console);
                    break;
                case "f":
                    iocInit(PrintType.File);
                    break;
                case "b":
                    iocInit(PrintType.Both);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
        public enum PrintType
        {
            Console,
            File,
            Both
        };
    }
}
