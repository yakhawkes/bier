using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Web.Http;
using log4net;

namespace Bier.Controllers
{
    [RoutePrefix("api")]
    public class BierController : ApiController
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Route("bier")]
        public HttpResponseMessage GetBeir()
        {
            this.Request.GetQueryString();
            IEnumerable<KeyValuePair<string, string>> queryStringnameValues = this.Request.GetQueryNameValuePairs();
            string url = $"http://api.brewerydb.com/v2/beers?key=400e2f3f8d21883ddc488e6d964f6cca&{this.Request.GetQueryString()}";
            var dumbCache = ApplicationDumbCache.DumbCache;
            try
            {
                var responeContent = dumbCache.GetResponse(url);
                ApplicationDumbCache.DumbCache = dumbCache;
                var respons = Request.CreateResponse(HttpStatusCode.OK);
                respons.Content = new StringContent(responeContent, Encoding.UTF8, "application/json");
                return respons;
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message, new JsonMediaTypeFormatter());
            }
        }
    }
}
