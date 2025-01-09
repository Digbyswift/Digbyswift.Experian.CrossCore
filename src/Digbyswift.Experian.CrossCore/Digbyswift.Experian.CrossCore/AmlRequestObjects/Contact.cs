using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Contact
{
    public string Id { get; }
#if NETFRAMEWORK
    public Person Person { get; set; }
#else
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
