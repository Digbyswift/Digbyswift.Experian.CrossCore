using System;
using System.Linq;
using System.Text.Json.Serialization;
using Digbyswift.Core.Constants;

namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Name
{
    public string Type { get; } = "Current";
    public string FirstName { get; set; }

    [JsonPropertyName("surName")]
    public string LastName { get; set; }

#if NETFRAMEWORK
    public string Title { get; set; }
    public string MiddleNames { get; set; }
#else
    public string? Title { get; set; }
    public string? MiddleNames { get; set; }

#endif

    public Name()
    {
    }

    public Name(string? title, string fullName)
    {
        Title = title;

        if (!fullName.Contains(CharConstants.Space))
        {
            FirstName = fullName;
            return;
        }

        var nameParts = fullName.Split(CharConstants.Space);

        FirstName = nameParts[0];
        MiddleNames = nameParts.Length > 2 ? nameParts[1] : null;
        LastName = nameParts.Length == 2 ? nameParts[1] : String.Join(StringConstants.Space, nameParts.Skip(2));
    }
}
