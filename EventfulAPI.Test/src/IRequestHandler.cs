using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test.src
{
    public interface IRequestHandler
    {
        /// <summary>
        /// This method makes http web request on the basis of given request object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HttpWebResponse MakeRequest(HttpWebRequest request);
    }
}
