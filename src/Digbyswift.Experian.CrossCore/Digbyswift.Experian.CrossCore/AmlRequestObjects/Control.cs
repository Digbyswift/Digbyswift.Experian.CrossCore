namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Control
{
    private const string DefaultOption = "KYC_CLIENTTIERVERSION";
    private const string DefaultValue = "Warwick";

    public string Option { get; } = DefaultOption;
    public string Value { get; } = DefaultValue;
}