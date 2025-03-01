using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class EmailAddress
{
    public string Id { get; set; }
    public string Type { get; } = "HOME";
#if NETFRAMEWORK
    public string Email { get; set; }
#else
    public string? Email { get; set; }
#endif

    public EmailAddress()
    {
        Id = Guid.NewGuid().FirstSegment().ToUpper();
    }

    public EmailAddress(string email) : this()
    {
        Email = email;
    }
}
