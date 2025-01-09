using System.Threading.Tasks;
using Digbyswift.Experian.Core.AmlRequestObjects;

namespace Digbyswift.Experian.Core.Services;

public interface IAmlService
{
    RequestPayload CreatePayload(AmlCheckDto dto);
    Task<AmlCheckResult> PerformCheckAsync(RequestPayload payload);
}