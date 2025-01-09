﻿using System.Collections.Generic;
using System.Linq;

namespace Digbyswift.Experian.Core;

public class AmlErrorResponse
{
    public IEnumerable<Error> Errors { get; set; } = Enumerable.Empty<Error>();
    public bool Success { get; set; }
}