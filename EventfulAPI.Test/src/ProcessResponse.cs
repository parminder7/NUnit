using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventfulAPI.Test.src
{
    public class ProcessResponse : IProcessResponse
    {
        public XmlDocument getXmlDocument(HttpWebResponse response)
        {
            try
            {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());
                    Console.WriteLine("I'm out here xml");
                    return (xmlDoc);
            }
            catch (XmlException exception)
            {
                throw exception;
            }
        }

        public string decodeErrorResponse(HttpWebResponse response)
        {
            try
            {
                XmlDocument document = getXmlDocument(response);
                XmlNode errorNodeElement = document.SelectSingleNode("error");
                string errString = errorNodeElement.Attributes["string"].Value;
                Console.WriteLine(errString);
                return errString;
            }
            catch(Exception ex)
            {
                throw new Exception(
                    String.Format("Illegal reference to either node or attribute: {0}"), ex);
            }
        }
    }
}
