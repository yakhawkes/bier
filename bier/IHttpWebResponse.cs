using System;
using System.IO;

namespace Bier
{
    public interface IHttpWebResponse : IDisposable
    {
        Stream GetResponseStream();
    }
}