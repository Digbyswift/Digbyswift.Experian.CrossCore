#if NETFRAMEWORK
using System.Configuration;
#else
#endif

namespace Digbyswift.Experian.CrossCore;

public class Endpoints
{
#if NETFRAMEWORK
    public string AmlServiceUrl { get; } = ConfigurationManager.AppSettings["Experian.AmlServiceUrl"];
    public string AuthTokenUrl { get; } = ConfigurationManager.AppSettings["Experian.AuthTokenUrl"];
#else
    public string AmlServiceUrl { get; }
    public string AuthTokenUrl { get; }

    public Endpoints(string amlServiceUrl, string authTokenUrl)
    {
        AmlServiceUrl = amlServiceUrl;
        AuthTokenUrl = authTokenUrl;
    }
#endif
}
