using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class PingRespose : IResponse
    {
        private Ping _pinger = new Ping();

        public StringBuilder Test(string webSite, int attempts)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                for (int i = 0; i < attempts; i++)
                {
                    PingReply Reply = _pinger.Send(webSite);
                    str.AppendLine(String.Format("Ping {0}: {1}", webSite, Reply.Status));
                }
                //_print.Print(String.Format("Ping {0}: {1}", _webSite, Reply.Status));
            }
            catch (Exception e)
            {
                str.Append(e.Message);
            }
            return str;
        }
    }
}
