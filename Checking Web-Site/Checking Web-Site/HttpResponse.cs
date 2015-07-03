using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    class HttpResponse : IResponse
    {

        public StringBuilder Test(string webSite, int attempts)
        {
            StringBuilder str = new StringBuilder();
            WebRequest request = WebRequest.Create(webSite);
            HttpWebResponse response;
            try
            {
                for (int i = 0; i < attempts; i++)
                {
                    response = (HttpWebResponse)request.GetResponse();
                    str.AppendLine(String.Format("Web Request {0}: {1}", webSite, response.StatusDescription));
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
