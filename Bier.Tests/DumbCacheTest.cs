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
        public void DumbCacheLogaInfoOnce()
        {
            string response = _dumbCache.GetResponse("theURL");
            _mockLogger.Verify(m => m.Info(It.IsAny<object>()), Times.Once);
        }
        [TestMethod]
        public void DumbCacheRLogsAdding()
        {
            string response = _dumbCache.GetResponse("theURL");
            Check.That<string>(_messages[0]).Equals("Adding to cache");
        }
        [TestMethod]
        public void DumbCacheReturnsSomeJson()
        {
            string response = _dumbCache.GetResponse("theURL");
            Check.That<string>(response).Equals("{\"some\": \"JSON\" }");
            _mockLogger.Verify(m => m.Info(It.IsAny<object>()), Times.Once);
            Check.That<string>(_messages[0]).Equals("Adding to cache");
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

            _logger.Info("Adding to cache");
            _cache.Add(key, "{\"some\": \"JSON\" }");
            return "{\"some\": \"JSON\" }";


        }
    }
}
