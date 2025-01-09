using Digbyswift.Experian.CrossCore.AmlResponseObjects;

namespace Digbyswift.Experian.CrossCore;

public class AmlResponse
{
#if NETFRAMEWORK
    public ResponseHeader ResponseHeader { get; set; }
#else
    public ResponseHeader? ResponseHeader { get; set; }
#endif
}
