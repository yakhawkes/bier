namespace Bier
{
    public interface IHttpWebRequest
    {
        string Method { get; set; }

        IHttpWebResponse GetResponse();
    }
}