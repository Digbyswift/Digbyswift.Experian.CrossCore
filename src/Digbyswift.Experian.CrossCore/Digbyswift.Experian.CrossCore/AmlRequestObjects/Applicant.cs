using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class Applicant
{
    public string Id { get; }
#if NETFRAMEWORK
    public string ContactId { get; set; }
#else
    public string? ContactId { get; set; }
#endif
    public string ApplicantType { get; } = "APPLICANT";

    public Applicant()
    {
        Id = $"APP{Guid.NewGuid().FirstSegment().ToUpper()}";
    }
}
