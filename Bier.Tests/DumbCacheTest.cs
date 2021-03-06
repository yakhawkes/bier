﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using log4net;
using NFluent;

namespace Bier.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private List<string> _messages;
        private Mock<ILog> _mockLogger;
        private DumbCache _dumbCache;
        private DumbCache _dumbBriefCache;
        private string _expectedPayload = "{\"some\": \"JSON\" }";
        private string _theurl = "theURL";
        private Mock<IHttpWebRequestFactory> _mockHttpWebRequestFactory;

        [TestInitialize]
        public void Init()
        {
            

            var response = new Mock<IHttpWebResponse>();
            response.Setup(c => c.GetResponseStream())
                .Returns(() =>
                {
                    var expectedBytes = Encoding.UTF8.GetBytes(_expectedPayload);
                    var responseStream = new MemoryStream();
                    responseStream.Write(expectedBytes, 0, expectedBytes.Length);
                    responseStream.Seek(0, SeekOrigin.Begin);
                    return responseStream;
                });

            var request = new Mock<IHttpWebRequest>();
            request.Setup(c => c.GetResponse()).Returns(response.Object);

            _mockHttpWebRequestFactory = new Mock<IHttpWebRequestFactory>();
            _mockHttpWebRequestFactory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(request.Object);

            _messages = new List<string>();
            _mockLogger = new Mock<ILog>();
            _mockLogger.Setup(m => m.Info(It.IsAny<object>()));
            _mockLogger.Setup(m => m.Info(It.IsAny<object>()))
                .Callback<object>(message => _messages.Add(message.ToString()));

            _dumbCache = new DumbCache(_mockLogger.Object, _mockHttpWebRequestFactory.Object);
            _dumbBriefCache = new DumbCache(_mockLogger.Object, _mockHttpWebRequestFactory.Object, 1);
        }


        [TestMethod]
        public void DumbCacheReturnsSomeJson()
        {
            string response = _dumbCache.GetResponse(_theurl);
            Check.That<string>(response).Equals(_expectedPayload);
        }
        [TestMethod]
        public void DumbCacheLogsInfoOnce()
        {
            string response = _dumbCache.GetResponse(_theurl);
            _mockLogger.Verify(m => m.Info(It.IsAny<object>()), Times.Once);
        }
        [TestMethod]
        public void DumbCacheLogsAdding()
        {
            string response = _dumbCache.GetResponse(_theurl);
            Check.That<string>(_messages[0]).Equals("Adding to cache");
        }

        [TestMethod]
        public void DumbCacheReturnsSomeJsonWithSameUrl()
        {
            string response = _dumbCache.GetResponse(_theurl);
            string response2 = _dumbCache.GetResponse(_theurl);

            Check.That<string>(response).Equals(_expectedPayload);
            Check.That<string>(response2).Equals(_expectedPayload);
        }
        [TestMethod]
        public void DumbCacheLogsInfoTwice()
        {
            string response = _dumbCache.GetResponse(_theurl);
            string response2 = _dumbCache.GetResponse(_theurl);

            _mockLogger.Verify(m => m.Info(It.IsAny<object>()), Times.Exactly(2));
        }
        [TestMethod]
        public void DumbCacheLogsGetting()
        {
            string response = _dumbCache.GetResponse(_theurl);
            string response2 = _dumbCache.GetResponse(_theurl);

            Check.That<string>(_messages[1]).Equals("Getting from cache");
        }

        [TestMethod]
        public void DumbCacheReturnsSomeJsonWithSameUrlWithDelay()
        {
            string response = _dumbBriefCache.GetResponse(_theurl);
            System.Threading.Thread.Sleep(1010);
            string response2 = _dumbBriefCache.GetResponse(_theurl);

            Check.That<string>(response).Equals(_expectedPayload);
            Check.That<string>(response2).Equals(_expectedPayload);
        }
        [TestMethod]
        public void DumbCacheLogsTwiceWithSameUrlWithDelay()
        {
            string response = _dumbBriefCache.GetResponse(_theurl);
            System.Threading.Thread.Sleep(1010);
            string response2 = _dumbBriefCache.GetResponse(_theurl);

            _mockLogger.Verify(m => m.Info(It.IsAny<object>()), Times.Exactly(2));
        }
        [TestMethod]
        public void DumbCacheLogsUpdatingWithSameUrlWithDelay()
        {
            string response = _dumbBriefCache.GetResponse(_theurl);
            System.Threading.Thread.Sleep(1010);
            string response2 = _dumbBriefCache.GetResponse(_theurl);

            Check.That<string>(_messages[0]).Equals("Adding to cache");
            Check.That<string>(_messages[1]).Equals("Updating cache");
        }
    }
}
