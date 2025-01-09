using System.Text.Json.Serialization;

namespace Digbyswift.Experian.CrossCore;

public class AccessTokenResponse
{
#if NETFRAMEWORK
    [JsonPropertyName("issued_at")]
    public string IssuedAt { get; set; }

    [JsonPropertyName("expires_in")]
    public string ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
#else
    [JsonPropertyName("issued_at")]
    public string? IssuedAt { get; set; }

    [JsonPropertyName("expires_in")]
    public string? ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }
#endif
}
