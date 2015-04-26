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
        /// <summary>
        /// This method returns the value of total_items node by parsing xml response in http web response object.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        long getTotalNumberOfSearchedItems(HttpWebResponse response);
    }
}
