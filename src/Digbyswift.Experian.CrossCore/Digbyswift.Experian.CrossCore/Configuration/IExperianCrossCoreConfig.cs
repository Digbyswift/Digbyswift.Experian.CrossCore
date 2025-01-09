namespace Digbyswift.Experian.CrossCore.Configuration;

public interface IExperianCrossCoreConfig
{
#if NETFRAMEWORK
    string AuthDomain { get; }
    string TenantId { get; }
    string ClientId { get; }
    string ClientSecret { get; }
    string Username { get; }
    string Password { get; }
#else
    string? AuthDomain { get; }
    string? TenantId { get; }
    string? ClientId { get; }
    string? ClientSecret { get; }
    string? Username { get; }
    string? Password { get; }
#endif
}
