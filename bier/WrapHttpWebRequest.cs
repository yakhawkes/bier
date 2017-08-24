using System.Net;

namespace Bier
{
    public class WrapHttpWebRequest : IHttpWebRequest
    {
        private readonly HttpWebRequest _request;

        public WrapHttpWebRequest(HttpWebRequest request)
        {
            _request = request;
        }

        public string Method
        {
            get { return _request.Method; }
            set { _request.Method = value; }
        }

        public IHttpWebResponse GetResponse()
        {
            return new WrapHttpWebResponse((HttpWebResponse)_request.GetResponse());
        }
    }
}