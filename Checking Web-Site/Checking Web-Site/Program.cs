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
                kernel.Bind<IResponse>().To<PingRespose>().InTransientScope();
            });
        }
        public static void iocChange()
        {
            IoC.Reset();
            Console.WriteLine("******************************");
            Console.WriteLine("To print log to console type c");
            Console.WriteLine("To print log to file type f");
            Console.WriteLine("To print log both ways type b");
            string input = Console.ReadLine();
            Console.WriteLine("******************************");
            Console.WriteLine("To check web-site over ping type p");
            Console.WriteLine("To check web-site over Http Request type h");
            string inputResponse = Console.ReadLine();
            Console.WriteLine("******************************");
            IoC.Init((kernel) =>
            {
                switch (input)
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
                        Console.WriteLine("Wrong print input, use default");
                        kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope();
                        break;
                }
                switch (inputResponse)
                {
                    case "p":
                        kernel.Bind<IResponse>().To<PingRespose>().InTransientScope();
                        break;
                    case "h":
                        kernel.Bind<IResponse>().To<HttpResponse>().InTransientScope();
                        break;
                    default:
                        Console.WriteLine("Wrong print input, use default");
                        kernel.Bind<IResponse>().To<PingRespose>().InTransientScope();
                        break;
                }
            });
        }
    }
}
