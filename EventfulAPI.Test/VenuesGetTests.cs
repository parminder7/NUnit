using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Xml;
using EventfulAPI.Test.src;

namespace EventfulAPI.Test
{
    /// <summary>
    /// This class contains some of the tests related to /venues/get API method
    /// </summary>
    public class VenuesGetTests : BaseFixture
    {
        [Test]
        public void VenuesGet_GetAuthenticationStatusError()
        {
            //Arrange
            var request = reqmgr.BuildRequest("venues/get", "invalidAppKeyForError");
            response = resmgr.MakeRequest(request);
            
            //Act
            IProcessResponse_Get gethdlr = new ProcessResponse_Get();
            string errString = gethdlr.decodeErrorResponse(response);

            //Assert
            StringAssert.AreEqualIgnoringCase("Authentication Error", errString);
        }

        [Test]
        public void VenuesGet_ShouldReturnVaildVenue()
        {
            //Arrange
            var parameters = new Dictionary<string, string>
                                                 {
                                                    {"id", "V0-001-000610243-3"}
                                                 };
            var request = reqmgr.BuildRequest("venues/get", parameters);
            response = resmgr.MakeRequest(request);
            
            //Act
            IProcessResponse_Get gethdlr = new ProcessResponse_Get();
            string stringText = gethdlr.getVenueName(response);

            //Assert
            StringAssert.AreEqualIgnoringCase("The Railway Club", stringText);
        }

        [Test]
        public void VenuesGet_PassNullVenueID()
        {
            //Arrange
            var parameters = new Dictionary<string, string>
                                                 {
                                                    {"id", null}
                                                 };
            var request = reqmgr.BuildRequest("venues/get", parameters);
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Get gethdlr = new ProcessResponse_Get();
            string errString = gethdlr.decodeErrorResponse(response);

            //Assert
            Assert.AreEqual("Missing parameter", errString);
        }

        [Test]
        public void VenuesGet_MissingVenueID()
        {
            //Arrange
            var request = reqmgr.BuildRequest("venues/get");
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Get gethdlr = new ProcessResponse_Get();
            string errString = gethdlr.decodeErrorResponse(response);

            //Assert
            StringAssert.AreEqualIgnoringCase("Missing parameter", errString);
        }

        [Test]
        public void VenuesGet_NotFoundPassedInvalidVenueID()
        {
            //Arrange
            var parameters = new Dictionary<string, string>
                                                 {
                                                    {"id", "invalidid"}
                                                 };
            var request = reqmgr.BuildRequest("venues/get", parameters);
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Get gethdlr = new ProcessResponse_Get();
            string errString = gethdlr.decodeErrorResponse(response);

            //Assert
            StringAssert.AreEqualIgnoringCase("Not found", errString);
        }

    }
}
