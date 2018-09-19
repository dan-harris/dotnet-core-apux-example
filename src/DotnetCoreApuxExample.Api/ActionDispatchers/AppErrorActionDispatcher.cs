using Apux;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Actions;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{
    /// <summary>
    /// Implements Actions for this Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class AppErrorActionsDispatcher : IApuxActionDispatcher
    {
        private readonly IAppErrorActionHandler _appErrorActionHandler;

        public AppErrorActionsDispatcher(IAppErrorActionHandler appErrorActionHandler)
        {
            _appErrorActionHandler = appErrorActionHandler;
        }

        public ApuxActionResultBase Dispatch(ApuxActionBase actionRequest)
        {
            switch (actionRequest.Type)
            {
                case AppErrorActions.INTERNAL_ERROR:
                    return _appErrorActionHandler.InternalErrorActionHandler(new InternalErrorAction());
                case AppErrorActions.UNKNOWN_ACTION:
                default:
                    return _appErrorActionHandler.UnknownActionHandler(new UnknownActionAction());
            }
        }
    }
}