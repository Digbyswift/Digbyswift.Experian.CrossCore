using System;
using Digbyswift.Experian.Core.AmlRequestObjects;

namespace Digbyswift.Experian.Core;

public class AmlRequest
{
    public RequestHeader Header { get; }

    public RequestPayload Payload { get; set; }

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