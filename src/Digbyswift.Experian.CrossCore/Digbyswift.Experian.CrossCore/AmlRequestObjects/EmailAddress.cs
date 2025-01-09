using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class EmailAddress
{
    public string Id { get; set; }
    public string Type { get; } = "HOME";
    public string Email { get; set; }

    public EmailAddress()
    {
        Id = Guid.NewGuid().FirstSegment().ToUpper();
    }

    public EmailAddress(string email) : this()
    {
        Email = email;
    }
}
