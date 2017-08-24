using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using log4net;

namespace Bier
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
        private readonly IHttpWebRequestFactory _httpWebRequestFactory;
        private readonly int _cacheTime;
        private readonly Dictionary<string, CacheEntry> _cache = new Dictionary<string, CacheEntry>();

        public DumbCache(ILog logger, IHttpWebRequestFactory httpWebRequestFactory, int cacheTime)
        {
            _logger = logger;
            _httpWebRequestFactory = httpWebRequestFactory;
            _cacheTime = cacheTime;
        }

        public DumbCache(ILog logger, IHttpWebRequestFactory httpWebRequestFactory) : this(logger, httpWebRequestFactory, 30000)
        {
        }

        public string GetResponse(string url)
        {
            if (_cache.ContainsKey(url))
            {
                if ((DateTime.Now - _cache[url].Created).TotalMilliseconds > _cacheTime)
                {
                    _logger.Info("Updating cache");
                    _cache[url] = new CacheEntry(DateTime.Now, FetchWebRequest(url));
                    return _cache[url].Data.ToString();
                }
                _logger.Info("Getting from cache");
                return _cache[url].Data.ToString();
            }
            _logger.Info("Adding to cache");

            _cache.Add(url, new CacheEntry(DateTime.Now, FetchWebRequest(url)));
            return _cache[url].Data.ToString();
        }

        private string FetchWebRequest(string url)
        {
            var webRequest = _httpWebRequestFactory.Create(url);
            webRequest.Method = WebRequestMethods.Http.Get;

            using (var httpWebResponse = webRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}