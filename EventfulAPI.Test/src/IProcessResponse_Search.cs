using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test.src
{
    interface IProcessResponse_Search : IProcessResponse
    {
        long getTotalNumberOfSearchedItems(HttpWebResponse response);
    }
}
