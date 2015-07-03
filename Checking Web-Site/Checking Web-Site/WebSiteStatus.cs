using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class WebSiteStatus
    {
        private static string _webSite;
        private static int _attempts;
        Ping _pinger;
        IPrint[] _print;
        static WebSiteStatus()
        {
            _webSite = "dou.ua";
            _attempts = 5;
        }
        public WebSiteStatus(IPrint[] print)
        {
            _print = print;
            _pinger = new Ping();
        }

        public void CheckStatus()
        {
            try
            {
                PingReply Reply = _pinger.Send(_webSite);
                for (int i = 0; i < _attempts; i++)
                {
                    foreach (var p in _print)
                    {
                        p.Print(String.Format("Ping {0}: {1}", _webSite, Reply.Status));
                    }
                }
                //_print.Print(String.Format("Ping {0}: {1}", _webSite, Reply.Status));
            }
            catch (Exception e)
            {
                foreach (var p in _print)
                {
                    p.Print(e.Message);
                }
            }

        }


        public void ChangeWebSite()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Input web-site address");
            _webSite = Console.ReadLine();
            Console.WriteLine("******************************");
        }
        public void ChangeAttempts()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Input web-site checking attempts");
            _attempts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("******************************");
        }
    }
}
