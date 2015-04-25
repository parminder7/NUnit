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
    public class EventsSearchTests : BaseFixture
    {
        [Test]
        public void EventsSearch_GetAuthenticationStatusError()
        {
            //Arrange
            var request = reqmgr.BuildRequest("events/search", "invalidAppKeyForError");
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Search searchhdlr = new ProcessResponse_Search();
            string errString = searchhdlr.decodeErrorResponse(response);

            //Assert
            StringAssert.AreEqualIgnoringCase("Authentication Error", errString);
        }

        [Test]
        public void EventsSearch_MissingParameters()
        {
            //Arrange
            var request = reqmgr.BuildRequest("events/search");
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Search searchhdlr = new ProcessResponse_Search();
            string errString = searchhdlr.decodeErrorResponse(response);

            //Assert
            StringAssert.AreEqualIgnoringCase("Missing parameter", errString);
        }

        [Test]
        public void EventsSearch_SearchByLegalKeywords()
        {
            //Arrange
            var parameters = new Dictionary<string, string>
                                                 {
                                                    {"keywords", "books"}
                                                 };
            var request = reqmgr.BuildRequest("events/search", parameters);
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Search searchhdlr = new ProcessResponse_Search();
            long total_items = searchhdlr.getTotalNumberOfSearchedItems(response);
            
            //Assert
            Assert.True(total_items > 0);
        }

        [Test]
        public void EventsSearch_SearchBySpecialCharKeywords()
        {
            //Arrange
            var parameters = new Dictionary<string, string>
                                                 {
                                                    {"keywords", "$É;"}
                                                 };
            var request = reqmgr.BuildRequest("events/search", parameters);
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Search searchhdlr = new ProcessResponse_Search();
            long total_items = searchhdlr.getTotalNumberOfSearchedItems(response);

            //Assert
            Assert.True(total_items == 0);
        }

        [Test]
        [ExpectedException(typeof(AssertionException), UserMessage = "EventfulAPI doesn't validate paramater")]
        public void EventsSearch_SearchByInvaildDateParameterNotSupported()
        {
            //Arrange
            var parameters = new Dictionary<string, string>
                                                 {
                                                     {"keywords", "play"},
                                                     {"date", "123"}
                                                 };
            var request = reqmgr.BuildRequest("events/search", parameters);
            response = resmgr.MakeRequest(request);

            //Act
            IProcessResponse_Search searchhdlr = new ProcessResponse_Search();
            long total_items = searchhdlr.getTotalNumberOfSearchedItems(response);

            //Assert
            Assert.True(total_items == 0);
        }
    }
}
