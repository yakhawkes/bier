namespace Bier
{
    public interface IHttpWebRequestFactory
    {
        IHttpWebRequest Create(string uri);
    }
}