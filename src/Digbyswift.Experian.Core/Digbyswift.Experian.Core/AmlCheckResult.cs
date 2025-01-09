namespace Digbyswift.Experian.Core;

public class AmlCheckResult
{
    public bool IsSuccess { get; }
    public string RequestId { get; set; }
    public AmlCheckStatus Status { get; set; }

    public AmlCheckResult(AmlCheckStatus status, string requestId)
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
