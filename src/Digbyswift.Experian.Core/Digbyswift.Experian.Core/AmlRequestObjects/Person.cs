using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Person
{
    public string TypeOfPerson { get; } = "APPLICANT";
    public string PersonIdentifier { get; }
    public Name[] Names { get; set; }

    public Person()
    {
        PersonIdentifier = $"PER{Guid.NewGuid().FirstSegment().ToUpper()}";
    }

    public Person(string? title, string fullName) : this()
    {
        Names =
        [
            new Name(title, fullName)
        ];
    }
}
