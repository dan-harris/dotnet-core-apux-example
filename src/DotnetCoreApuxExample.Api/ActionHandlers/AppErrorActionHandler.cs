using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public class AppErrorActionHandler : IAppErrorActionHandler
    {

        public ApuxActionResult UnknownAction() => new ApuxActionResult
        {
            Errors = new List<AppError> { new AppError { Type = AppError.ErrorType.ERROR, Value = "Unknown Action" } }
        };

    }
}