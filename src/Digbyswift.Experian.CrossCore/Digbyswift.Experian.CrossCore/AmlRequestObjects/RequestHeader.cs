using System;
using System.Text.Json.Serialization;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class RequestHeader
{
    public string RequestType { get; set; } = "CCIS-Full";

#if NETFRAMEWORK
    [JsonPropertyName("tenantID")]
    public string TenantId { get; set; }

    public string ClientReferenceId { get; set; }

    [JsonPropertyName("txnId")]
    public string TransactionId { get; set; }
#else
    [JsonPropertyName("tenantID")]
    public string? TenantId { get; set; }

    public string? ClientReferenceId { get; set; }

    [JsonPropertyName("txnId")]
    public string? TransactionId { get; set; }
#endif

    public string MessageTime { get; } = $"{DateTimeOffset.UtcNow:s}Z";

    public object Options { get; } = new();
}
