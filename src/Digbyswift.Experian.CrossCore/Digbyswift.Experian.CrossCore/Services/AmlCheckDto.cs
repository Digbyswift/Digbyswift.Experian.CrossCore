using System;

namespace Digbyswift.Experian.CrossCore.Services;

public class AmlCheckDto
{
    public string FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

#if NETFRAMEWORK
    public string Title { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string TownCity { get; set; }
    public string County { get; set; }
    public string PostCode { get; set; }
#else
    public string? Title { get; set; }
    public string? Email { get; set; }
    public string? Telephone { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? TownCity { get; set; }
    public string? County { get; set; }
    public string? PostCode { get; set; }
#endif

    public AmlCheckDto(string fullName)
    {
        FullName = fullName;
    }
}
