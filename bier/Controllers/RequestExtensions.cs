using System.Linq;
using System.Net.Http;

namespace Bier.Controllers
{
    public static class RequestExtensions
    {
        public static string GetQueryString(this HttpRequestMessage request)
        {
            var v = request.GetQueryNameValuePairs();
            if (!v.Any()) return "";
            return request.GetQueryNameValuePairs().Select(x => x.Key + "=" + x.Value).Aggregate((i, j) => i + "&" + j);
        }
    }
}