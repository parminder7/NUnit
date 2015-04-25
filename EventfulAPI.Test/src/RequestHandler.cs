using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test.src
{
    class RequestHandler : IRequestHandler
    {
        public HttpWebResponse MakeRequest(HttpWebRequest request)
        {
            try 
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Console.WriteLine("Exited response");
                return response;
            }
            catch(WebException ex)
            {
                throw new Exception(String.Format("Request failed for Url: {0}, {1}", 
                                                            request.RequestUri, 
                                                            ex.Status.ToString())
                                                            );
            }
        }
    }
}
