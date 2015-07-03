using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class WebSiteStatus
    {
        private static string _webSite;
        private static int _attempts;
        IPrint[] _print;
        private static IResponse _response = new PingRespose();
        [Inject]
        public IResponse Response
        {
            get { return _response; }
            set { _response = value; }
        }
        static WebSiteStatus()
        {
            _webSite = "http://dou.ua";
            _attempts = 5;
        }
        public WebSiteStatus(IPrint[] print)
        {
            _print = print;
        }

        public void CheckStatus()
        {
            try
            {
                foreach (var p in _print)
                {
                    p.Print(Response.Test(_webSite, _attempts));
                }
            }
            catch (Exception e)
            {
                foreach (var p in _print)
                {
                    p.Print(new StringBuilder(e.Message));
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
