namespace Digbyswift.Experian.CrossCore;

public class AmlCheckResult
{
    public bool IsSuccess { get; }
#if NETFRAMEWORK
    public string RequestId { get; set; }
#else
    public string? RequestId { get; set; }
#endif
    public AmlCheckStatus Status { get; set; }

#if NETFRAMEWORK
    public AmlCheckResult(AmlCheckStatus status, string requestId)
#else
    public AmlCheckResult(AmlCheckStatus status, string? requestId)
#endif
    {
        RequestId = requestId;
        Status = status;
        IsSuccess = status == AmlCheckStatus.Success;
    }

    public static AmlCheckResult Success(string requestId)
    {
        return new AmlCheckResult(AmlCheckStatus.Success, requestId);
    }

    public static AmlCheckResult Disabled()
    {
        return new AmlCheckResult(AmlCheckStatus.Disabled, null);
    }

    public static AmlCheckResult NotRequired()
    {
        return new AmlCheckResult(AmlCheckStatus.NotRequired, null);
    }
}
