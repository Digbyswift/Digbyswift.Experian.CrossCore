namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Headers
{
#if NETFRAMEWORK
    public string HeaderName { get; set; }
    public string HeaderValue { get; set; }
#else
    public string? HeaderName { get; set; }
    public string? HeaderValue { get; set; }
#endif
}
