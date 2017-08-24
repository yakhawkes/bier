using System;
using System.IO;

namespace Bier.Tests
{
    public interface IHttpWebResponse : IDisposable
    {
        // expose the members you need
        Stream GetResponseStream();
    }
}