using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test.src
{
    public interface IRequestBuilder
    {
        /// <summary>
        /// This method creates the instance of HttpWebRequest.
        /// It takes either events/search or venues/get EventfulAPI method name as methodName.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="eventfulAppKey" optional="true"></param>
        /// <returns></returns>
        HttpWebRequest BuildRequest(string methodName, string eventfulAppKey = null);

        /// <summary>
        /// This method creates the instance of HttpWebRequest.
        /// It takes either events/search or venues/get EventfulAPI method name as methodName.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <param name="eventfulAppKey" optional="true"></param>
        /// <returns></returns>
        HttpWebRequest BuildRequest(string methodName, Dictionary<string, string> parameters, string eventfulAppKey = null);
    }
}
