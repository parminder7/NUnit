using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventfulAPI.Test.src
{
    public class ProcessResponse_Search : ProcessResponse, IProcessResponse_Search
    {
        public long getTotalNumberOfSearchedItems(HttpWebResponse response)
        {
            try
            {
                XmlDocument document = getXmlDocument(response);
                XmlNode errorNodeElement = document.SelectSingleNode("search/total_items");
                long total_items = Int64.Parse(errorNodeElement.InnerText);
                Console.WriteLine(total_items);
                return total_items;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    String.Format("Illegal reference to either node or attribute: {0}"), ex);
            }
        }
    }
}
