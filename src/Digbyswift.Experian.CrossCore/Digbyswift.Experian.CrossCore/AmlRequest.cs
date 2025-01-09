using System;
using Digbyswift.Experian.CrossCore.AmlRequestObjects;

namespace Digbyswift.Experian.CrossCore;

public class AmlRequest
{
#if NETFRAMEWORK
    public RequestHeader Header { get; }
    public RequestPayload Payload { get; set; }
#else
    public RequestHeader? Header { get; }
    public RequestPayload? Payload { get; set; }
#endif

    public AmlRequest(string clientReferenceId, string tenantId)
    {
        Header = new()
        {
            TransactionId = $"TRN{Guid.NewGuid().ToString("N").ToUpper()}",
            ClientReferenceId = clientReferenceId,
            TenantId = tenantId
        };
    }
}
