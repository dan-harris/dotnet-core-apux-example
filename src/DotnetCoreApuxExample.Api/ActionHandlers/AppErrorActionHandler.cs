using Apux;
using Apux.Extensions;
using DotnetCoreApuxExample.Api.Actions;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public class AppErrorActionHandler : IAppErrorActionHandler
    {

        public ApuxActionResultBase UnknownActionHandler(UnknownActionAction action)
        {
            return new ApuxError(ApuxError.ErrorType.ERROR, "Unknown Action").ToApuxActionResult();
        }

        public ApuxActionResultBase InternalErrorActionHandler(InternalErrorAction action)
        {
            return new ApuxError(ApuxError.ErrorType.ERROR, "Internal Error").ToApuxActionResult();
        }
    }
}