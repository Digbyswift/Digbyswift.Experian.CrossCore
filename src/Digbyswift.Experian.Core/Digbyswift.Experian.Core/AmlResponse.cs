using Digbyswift.Experian.Core.AmlResponseObjects;

namespace Digbyswift.Experian.Core;

public class AmlResponse
{
#if NETFRAMEWORK
    public ResponseHeader ResponseHeader { get; set; }
#else
    public ResponseHeader? ResponseHeader { get; set; }
#endif
}
