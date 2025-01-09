namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Address
{
    public string AddressType { get; } = "CURRENT";
    public string Indicator { get; } = "RESIDENTIAL";
    public string BuildingNumber { get; } = "0";
#if NETFRAMEWORK
    public string Street { get; set; }
    public string PostTown { get; set; }
    public string County { get; set; }
    public string Postal { get; set; }
#else
    public string? Street { get; set; }
    public string? PostTown { get; set; }
    public string? County { get; set; }
    public string? Postal { get; set; }
#endif
    public string CountryCode { get; } = "GBR";
}
