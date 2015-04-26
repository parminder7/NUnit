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
        /// <summary>
        /// This method returns venue name by parsing xml response in http web response object.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        string getVenueName(HttpWebResponse response);
    }
}
