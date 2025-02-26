using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Person
{
    public string TypeOfPerson { get; } = "APPLICANT";
    public string PersonIdentifier { get; }
    public Name[] Names { get; set; }
    public PersonDetails Details { get; set; }

    public Person()
    {
        PersonIdentifier = $"PER{Guid.NewGuid().FirstSegment().ToUpper()}";
    }

#if NETFRAMEWORK
    public Person(string title, string fullName) : this()
#else
    public Person(string? title, string fullName) : this()
#endif
    {
        Names =
        [
            new Name(title, fullName)
        ];
    }
}
