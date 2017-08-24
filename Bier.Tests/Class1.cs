//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using NFluent;

//namespace Bier.Tests
//{
//    [TestClass]
//    public class Class1
//    {
//        [TestMethod]
//        public void Create_should_create_request_and_respond_with_stream()
//        {
//            // arrange
//            var expected = "response content";
//            var expectedBytes = Encoding.UTF8.GetBytes(expected);
//            var responseStream = new MemoryStream();
//            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
//            responseStream.Seek(0, SeekOrigin.Begin);

//            var response = new Mock<IHttpWebResponse>();
//            response.Setup(c => c.GetResponseStream())
//                .Returns(() =>
//                {
//                    responseStream.Seek(0, SeekOrigin.Begin);
//                    return responseStream;
//                });

//            var request = new Mock<IHttpWebRequest>();
//            request.Setup(c => c.GetResponse()).Returns(response.Object);

//            var factory = new Mock<IHttpWebRequestFactory>();
//            factory.Setup(c => c.Create(It.IsAny<string>()))
//                .Returns(request.Object);

//            // act
//            var actualRequest = factory.Object.Create("http://www.google.com");
//            actualRequest.Method = WebRequestMethods.Http.Get;

//            string actual;

//            using (var httpWebResponse = actualRequest.GetResponse())
//            {
//                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
//                {
//                    actual = streamReader.ReadToEnd();
//                }
//            }


//            // assert
//            Check.That<string>(actual).Equals(expected);
//        }

       

//        private class HttpWebRequestFactory : IHttpWebRequestFactory
//        {
//            public IHttpWebRequest Create(string uri)
//            {
//                return new WrapHttpWebRequest((HttpWebRequest)WebRequest.Create(uri));
//            }
//        }

//        public class WrapHttpWebRequest : IHttpWebRequest
//        {
//            private readonly HttpWebRequest _request;

//            public WrapHttpWebRequest(HttpWebRequest request)
//            {
//                _request = request;
//            }

//            public string Method
//            {
//                get { return _request.Method; }
//                set { _request.Method = value; }
//            }

//            public IHttpWebResponse GetResponse()
//            {
//                return new WrapHttpWebResponse((HttpWebResponse)_request.GetResponse());
//            }
//        }

//        public class WrapHttpWebResponse : IHttpWebResponse
//        {
//            private WebResponse _response;

//            public WrapHttpWebResponse(HttpWebResponse response)
//            {
//                _response = response;
//            }

//            public void Dispose()
//            {
//                Dispose(true);
//                GC.SuppressFinalize(this);
//            }

//            private void Dispose(bool disposing)
//            {
//                if (disposing)
//                {
//                    if (_response != null)
//                    {
//                        ((IDisposable)_response).Dispose();
//                        _response = null;
//                    }
//                }
//            }

//            public Stream GetResponseStream()
//            {
//                return _response.GetResponseStream();
//            }
//        }
//    }
//}


