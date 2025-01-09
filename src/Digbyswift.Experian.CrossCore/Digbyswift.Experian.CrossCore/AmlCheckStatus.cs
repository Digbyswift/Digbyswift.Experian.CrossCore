namespace Digbyswift.Experian.CrossCore;

public enum AmlCheckStatus
{
    /// <summary>
    /// The AML check returned a successful result for the individual being checked.
    /// </summary>
    Success = 0,

    /// <summary>
    /// The AML check returned a failed result for the individual being checked.
    /// </summary>
    Failed = 1,

    /// <summary>
    /// The AML check errored and was unable to return a result.
    /// </summary>
    Error = 50,

    /// <summary>
    /// The AML check is disabled.
    /// </summary>
    Disabled = 100,

    /// <summary>
    /// The AML check is not required, usually because the user has already been checked.
    /// </summary>
    NotRequired = 150
}