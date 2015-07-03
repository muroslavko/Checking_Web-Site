using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_Web_Site
{
    interface IResponse
    {
        StringBuilder Test(string webSite, int attempts);
    }
}
