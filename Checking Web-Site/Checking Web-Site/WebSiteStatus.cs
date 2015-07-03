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
        public string WebSite { get; set; }
        Ping _pinger;
        IPrint _print;

        public WebSiteStatus(IPrint print)
        {
            _print = print;
            WebSite = "dou.ua";
            _pinger = new Ping();
        }

        public void CheckStatus()
        {
            try
            {
                PingReply Reply =_pinger.Send(WebSite);
                //foreach (var p in _print)
                //{
                //    p.Print( String.Format("Ping {0}: {1}", WebSite, Reply.Status));
                //}
                _print.Print( String.Format("Ping {0}: {1}", WebSite, Reply.Status));
            }
            catch (Exception e) 
            {
                _print.Print(e.Message);
            }

        }

    }
}
