﻿using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Applicant
{
    public string Id { get; }
    public string ContactId { get; set; }
    public string ApplicantType { get; } = "APPLICANT";

    public Applicant()
    {
        Id = $"APP{Guid.NewGuid().FirstSegment().ToUpper()}";
    }
}
