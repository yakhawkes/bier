using System;
using System.Collections.Generic;
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
        private string _expectedPayload = "{\"some\": \"JSON\" }";
        private string _theurl = "theURL";

        [TestInitialize]
        public void Init()
        {
            _messages = new List<string>();
            _mockLogger = new Mock<ILog>();
            _mockLogger.Setup(m => m.Info(It.IsAny<object>()));
            _mockLogger.Setup(m => m.Info(It.IsAny<object>()))
                .Callback<object>(message => _messages.Add(message.ToString()));

            _dumbCache = new DumbCache(_mockLogger.Object, 1);
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
    }

    public class DumbCache
    {
        private readonly ILog _logger;
        private readonly int _cacheTime;
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public DumbCache(ILog logger, int cacheTime)
        {
            _logger = logger;
            _cacheTime = cacheTime;
        }

        public string GetResponse(string key)
        {
            if (_cache.ContainsKey(key))
            {
                _logger.Info("Getting from cache");
                return _cache[key];
            }
            _logger.Info("Adding to cache");
            _cache.Add(key, "{\"some\": \"JSON\" }");
            return "{\"some\": \"JSON\" }";
        }
    }
}
