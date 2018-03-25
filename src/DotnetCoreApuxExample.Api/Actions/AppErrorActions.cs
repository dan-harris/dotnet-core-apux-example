using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Actions
{
    /// <summary>
    /// List of Actions for this Apux Action namespace
    /// </summary>
    public class AppErrorActions
    {

        public const string UNKNOWN_ACTION = "APP_UNKNOWN_ACTION";

        public const string INTERNAL_ERROR = "APP_INTERNAL_ERROR";
    }

    public class UnknownActionAction : ApuxAction<JToken>
    {
        public UnknownActionAction() : base(AppErrorActions.UNKNOWN_ACTION) { }
    }

    public class InternalErrorAction : ApuxAction<JToken>
    {
        public InternalErrorAction() : base(AppErrorActions.INTERNAL_ERROR) { }
    }


}