using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.Actions
{
    public interface IApuxAction
    {
        ApuxActionResult executeAction(ApuxActionRequest actionRequest);

    }
}