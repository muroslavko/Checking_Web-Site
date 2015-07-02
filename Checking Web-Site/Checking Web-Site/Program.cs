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
            List<string> IPs = new List<string>();
            IPs.Add("10.1.1.12");
            IPs.Add("10.1.1.15");
            IPs.Add("OAOkomp1");
            IPs.Add("192.168.1.1");
            IPs.Add("www.google.com");
            IPs.Add("www.amazon.com");
            IPs.Add("dou.ua");
            System.Net.NetworkInformation.Ping Pinger =
                new System.Net.NetworkInformation.Ping();
            foreach (string ip in IPs)
            {
                try
                {
                    System.Net.NetworkInformation.PingReply Reply = Pinger.Send(ip);
                    Console.WriteLine(String.Format("Ping {0}: {1}", ip, Reply.Status));
                }
                catch (Exception) { }
            }
            Console.ReadLine();
        }
    }
}
