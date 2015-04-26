using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventfulAPI.Test.src
{
    interface IProcessResponse
    {
        /// <summary>
        /// This method returns xml response.
        /// It can be used when there is a need of customized parsing. :P
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        XmlDocument getXmlDocument(HttpWebResponse response);

        /// <summary>
        /// This method returns error string by parsing xml response in http web response object.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        string decodeErrorResponse(HttpWebResponse response);
    }
}
