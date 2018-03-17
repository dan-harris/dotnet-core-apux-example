using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.Actions
{
    /// <summary>
    /// List of Actions for this Apux Action namespace
    /// </summary>
    public class AppErrorActionsList
    {
        public const string UNKNOWN_ACTION = "UNKNOWN_ACTION";
    }

    /// <summary>
    /// Implements Actions for this Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class AppErrorActions : IApuxAction
    {

        private readonly IAppErrorActionHandler _appErrorActionHandler;

        public AppErrorActions(IAppErrorActionHandler appErrorActionHandler)
        {
            _appErrorActionHandler = appErrorActionHandler;
        }

        public ApuxActionResult executeAction(ApuxActionRequest actionRequest)
        {

            var result = _appErrorActionHandler.UnknownAction();

            switch (actionRequest.Action)
            {
                case AppErrorActionsList.UNKNOWN_ACTION:
                default:
                    {
                        result = _appErrorActionHandler.UnknownAction();
                    }
                    break;
            }

            return result;

        }

    }
}