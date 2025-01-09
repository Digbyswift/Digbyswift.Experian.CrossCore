#if NETFRAMEWORK
using System.Configuration;
#else
#endif

namespace Digbyswift.Experian.CrossCore.Configuration;

public class ExperianCrossCoreConfig : IExperianCrossCoreConfig
{
#if NETFRAMEWORK
    public string AuthDomain { get; } = ConfigurationManager.AppSettings["Experian.AuthDomain"];
    public string TenantId { get; } = ConfigurationManager.AppSettings["Experian.TenantId"];
    public string ClientId { get; } = ConfigurationManager.AppSettings["Experian.ClientId"];
    public string ClientSecret { get; } = ConfigurationManager.AppSettings["Experian.ClientSecret"];
    public string Username { get; } = ConfigurationManager.AppSettings["Experian.Username"];
    public string Password { get; } = ConfigurationManager.AppSettings["Experian.Password"];
#else
    public string AuthDomain { get; }
    public string TenantId { get; }
    public string ClientId { get; }
    public string ClientSecret { get; }
    public string Username { get; }
    public string Password { get; }

    public ExperianCrossCoreConfig(string tenantId, string clientId, string clientSecret, string authDomain, string username, string password)
    {
        TenantId = tenantId;
        ClientId = clientId;
        ClientSecret = clientSecret;
        AuthDomain = authDomain;
        Username = username;
        Password = password;
    }
#endif
}
