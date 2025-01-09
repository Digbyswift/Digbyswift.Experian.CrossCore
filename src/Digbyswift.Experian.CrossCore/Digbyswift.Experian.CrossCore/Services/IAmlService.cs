using System.Threading.Tasks;
using Digbyswift.Experian.CrossCore.AmlRequestObjects;

namespace Digbyswift.Experian.CrossCore.Services;

public interface IAmlService
{
    RequestPayload CreatePayload(AmlCheckDto dto);
    Task<AmlCheckResult> PerformCheckAsync(RequestPayload payload);
}