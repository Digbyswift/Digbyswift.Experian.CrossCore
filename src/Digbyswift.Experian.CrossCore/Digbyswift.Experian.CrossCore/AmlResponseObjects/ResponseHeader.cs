using System.Text.Json.Serialization;

namespace Digbyswift.Experian.CrossCore.AmlResponseObjects;

public class ResponseHeader
{
#if NETFRAMEWORK
    [JsonPropertyName("requestType")]
    public string RequestType { get; set; }

    [JsonPropertyName("clientReferenceId")]
    public string ClientReferenceId { get; set; }

    [JsonPropertyName("expRequestId")]
    public string ExpRequestId { get; set; }

    [JsonPropertyName("messageTime")]
    public string MessageTime { get; set; }

    [JsonPropertyName("overallResponse")]
    public OverallResponse OverallResponse { get; set; }

    [JsonPropertyName("responseCode")]
    public string ResponseCode { get; set; }

    [JsonPropertyName("responseType")]
    public string ResponseType { get; set; }

    [JsonPropertyName("responseMessage")]
    public string ResponseMessage { get; set; }

    [JsonPropertyName("tenantID")]
    public string TenantId { get; set; }
#else
    [JsonPropertyName("requestType")]
    public string? RequestType { get; set; }

    [JsonPropertyName("clientReferenceId")]
    public string? ClientReferenceId { get; set; }

    [JsonPropertyName("expRequestId")]
    public string? ExpRequestId { get; set; }

    [JsonPropertyName("messageTime")]
    public string? MessageTime { get; set; }

    [JsonPropertyName("overallResponse")]
    public OverallResponse? OverallResponse { get; set; }

    [JsonPropertyName("responseCode")]
    public string? ResponseCode { get; set; }

    [JsonPropertyName("responseType")]
    public string? ResponseType { get; set; }

    [JsonPropertyName("responseMessage")]
    public string? ResponseMessage { get; set; }

    [JsonPropertyName("tenantID")]
    public string? TenantId { get; set; }
#endif
}
