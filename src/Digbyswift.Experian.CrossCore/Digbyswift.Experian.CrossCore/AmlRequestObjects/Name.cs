using System;
using System.Linq;
using System.Text.Json.Serialization;
using Digbyswift.Core.Constants;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Name
{
    public string Type { get; } = "Current";

#if NETFRAMEWORK
    public string Title { get; set; }
    public string FirstName { get; set; }

    [JsonPropertyName("surName")]
    public string LastName { get; set; }
    public string MiddleNames { get; set; }
#else
    public string? Title { get; set; }
    public string? FirstName { get; set; }

    [JsonPropertyName("surName")]
    public string? LastName { get; set; }
    public string? MiddleNames { get; set; }

#endif

    public Name()
    {
    }

#if NETFRAMEWORK
    public Name(string title, string fullName)
#else
    public Name(string? title, string fullName)
#endif
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
