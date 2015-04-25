using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventfulAPI.Test.src
{
    public class ProcessResponse_Get : ProcessResponse, IProcessResponse_Get
    {
        public string getVenueName(HttpWebResponse response)
        {
            try
            {
                XmlDocument document = getXmlDocument(response);
                XmlNode nameNodeElement = document.SelectSingleNode("venue/name");
                string stringText = nameNodeElement.InnerText;
                Console.WriteLine(stringText);
                return stringText;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    String.Format("Illegal reference to either node or attribute: {0}"), ex);
            }
        }
    }
}
