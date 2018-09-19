using Apux;

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

    public class UnknownActionAction : ApuxActionBase
    {
        public UnknownActionAction() : base(AppErrorActions.UNKNOWN_ACTION) { }
    }

    public class InternalErrorAction : ApuxActionBase
    {
        public InternalErrorAction() : base(AppErrorActions.INTERNAL_ERROR) { }
    }
}