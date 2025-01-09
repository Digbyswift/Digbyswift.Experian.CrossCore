using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Telephone
{
    public string Number { get; }
    public string InternationalCode { get; } = "44";
    public string PhoneIdentifier { get; set; }

    public Telephone(string telephoneNumber)
    {
        var sanitizedNumber = telephoneNumber.RemoveNonWordCharacters();

        Number = sanitizedNumber;
        PhoneIdentifier = sanitizedNumber.StartsWith("07") || telephoneNumber.StartsWith("4407") || telephoneNumber.StartsWith("447")
            ? "MOBILE"
            : "HOME";
    }
}
