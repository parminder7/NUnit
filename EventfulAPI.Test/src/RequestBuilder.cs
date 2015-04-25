using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test.src
{
    class RequestBuilder : IRequestBuilder
    {
        private const string EventfulAppKey = "VP4qPpGtwBStrwQt";
        
        private string CreateRequestURL(string methodName, string queryString, string eventfulAppKey)
        {
            if(eventfulAppKey == null)
            {
                eventfulAppKey = EventfulAppKey;
            }
            string requestUrl = "http://api.eventful.com/rest/" +
                                 methodName +
                                 "?app_key=" + eventfulAppKey +
                                 "&" + queryString;

            return (requestUrl);
        }

        public HttpWebRequest BuildRequest(string methodName, string eventfulAppKey)
        {
            string requestUrl = CreateRequestURL(methodName, null, eventfulAppKey);
            Console.WriteLine(requestUrl);
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            return request;
        }

        public HttpWebRequest BuildRequest(string methodName, Dictionary<string, string> parameters, string eventfulAppKey)
        {
            string query = CreateQueryString(parameters);
            string requestUrl = CreateRequestURL(methodName, query, eventfulAppKey);
            Console.WriteLine(requestUrl);
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            return request;
        }

        private string CreateQueryString(Dictionary<string, string> parameters)
        {
            var query = new StringBuilder();
            int count = 0;
            bool endflag = false;

            foreach (var key in parameters.Keys)
            {
                if (count == (parameters.Count - 1))
                {
                    endflag = true;
                }

                if (endflag)
                {
                    query.AppendFormat("{0}={1}", key, parameters[key]);
                }
                else
                {
                    query.AppendFormat("{0}={1}&", key, parameters[key]);
                }

                count++;
            }

            return query.ToString();
        }
    }
}
