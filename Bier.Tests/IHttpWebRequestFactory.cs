namespace Bier.Tests
{
    public interface IHttpWebRequestFactory
    {
        IHttpWebRequest Create(string uri);
    }
}