namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Device
{
#if NETFRAMEWORK
    public string Id { get; set; }
    public string IpAddress { get; set; }
    public Headers[] Headers { get; set; }
#else
    public string? Id { get; set; }
    public string? IpAddress { get; set; }
    public Headers[] Headers { get; set; } = [];
#endif
}
