namespace Digbyswift.Experian.CrossCore;

public class Error
{
#if NETFRAMEWORK
    public string ErrorType { get; set; }
    public string Message { get; set; }
#else
    public string? ErrorType { get; set; }
    public string? Message { get; set; }
#endif
}
