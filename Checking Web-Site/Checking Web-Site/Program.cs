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

            var obj = IoC.Get<WebSiteStatus>();

            obj.CheckStatus();
            Console.ReadLine();
        }

        private static void iocInit()
        {
            IoC.Init((kernel) =>
            {
                    kernel.Bind<IPrint>().To<PrintToConsole>().InTransientScope(); // default
                    //kernel.Bind<IPrint>().To<PrintToFile>().InTransientScope();
            });
        }
    }
}
