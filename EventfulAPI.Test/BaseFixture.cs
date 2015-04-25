using EventfulAPI.Test.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAPI.Test
{
    [TestFixture]
    public class BaseFixture
    {
        public IRequestBuilder reqmgr;
        public IRequestHandler resmgr;
        public HttpWebResponse response;

        [SetUp]
        public void setupInitialize()
        {
            reqmgr = new RequestBuilder();
            resmgr = new RequestHandler();
        }

        [TearDown]
        public void teardownCleanUp()
        {
            response.Close();
        }
    }
}
