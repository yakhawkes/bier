using System;
using System.Collections.Generic;
using log4net;

namespace Bier.Tests
{
    public class DumbCache
    {
        private class CacheEntry
        {
            public DateTime Created { get; }
            public object Data { get; }

            public CacheEntry(DateTime created, object data)
            {
                Created = created;
                Data = data;
            }
        }
        private readonly ILog _logger;
        private readonly int _cacheTime;
        private readonly Dictionary<string, CacheEntry> _cache = new Dictionary<string, CacheEntry>();

        public DumbCache(ILog logger, int cacheTime)
        {
            _logger = logger;
            _cacheTime = cacheTime;
        }

        public DumbCache(ILog logger) : this(logger, 30000)
        {
        }

        public string GetResponse(string key)
        {
            if (_cache.ContainsKey(key))
            {
                if ((DateTime.Now - _cache[key].Created).TotalMilliseconds > _cacheTime)
                {
                    _logger.Info("Updating cache");
                    return _cache[key].Data.ToString();
                }
                _logger.Info("Getting from cache");
                return _cache[key].Data.ToString();
            }
            _logger.Info("Adding to cache");
            _cache.Add(key, new CacheEntry(DateTime.Now, "{\"some\": \"JSON\" }"));
            return "{\"some\": \"JSON\" }";
        }
    }
}