using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test.src
{
    interface IProcessResponse_Get : IProcessResponse
    {
        string getVenueName(HttpWebResponse response);
    }
}
