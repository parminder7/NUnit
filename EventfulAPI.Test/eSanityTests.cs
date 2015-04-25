using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventfulAPI.Test.src;
using System.Net;

namespace EventfulAPI.Test
{
    public class eSanityTests : BaseFixture
    {
        [Test]
        public void eSanity_HttpResponseIsSuccessWithOKStatusCode()
        {
            //Arrange
            var request = reqmgr.BuildRequest("venues/get");

            //Act
            response = resmgr.MakeRequest(request);
            var status = response.StatusCode;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, status);
        }

        [Test]
        public void eSanity_HttpResponseIsXML()
        {
            //Arrange
            var request = reqmgr.BuildRequest("venues/get");

            //Act
            response = resmgr.MakeRequest(request);
            string contentType = response.ContentType;

            //Assert
            Assert.AreEqual("text/xml", contentType.Substring(0, contentType.IndexOf(";")));
        }
    }
}
