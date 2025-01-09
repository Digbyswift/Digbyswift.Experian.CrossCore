using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Contact
{
#if NETFRAMEWORK
    public string Id { get; }
    public Person Person { get; set; }
#else
    public string? Id { get; }
    public Person? Person { get; set; }
#endif
    public Address[] Addresses { get; set; } = [];
    public Telephone[] Telephones { get; set; } = [];
    public EmailAddress[] Emails { get; set; } = [];

    public Contact()
    {
        Id = $"CON{Guid.NewGuid().FirstSegment().ToUpper()}";
    }
}
