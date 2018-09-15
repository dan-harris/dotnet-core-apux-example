using Apux;
using DotnetCoreApuxExample.Api.Actions;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{
    public interface IAppErrorActionHandler
    {
        ApuxActionResultBase UnknownActionHandler(UnknownActionAction action);
        ApuxActionResultBase InternalErrorActionHandler(InternalErrorAction action);
    }
}