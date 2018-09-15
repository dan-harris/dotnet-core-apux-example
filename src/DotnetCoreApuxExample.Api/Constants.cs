namespace DotnetCoreApuxExample.Api
{
    public class Constants
    {
        /// <summary>
        /// Namespace prefix for actions
        /// (also used to determine which action set to use in DI)
        /// </summary>
        public class ActionNamespace
        {
            public const string ALL = "ALL"; // this isnt technically an action namespace - its used when we need to deal with any possible action
            public const string APP = "APP";
            public const string CART = "CART";
            public const string PRODUCT = "PRODUCT";
        }

        /// <summary>
        /// Seperator used in Actions
        /// Required to split the namespace of the action from the rest of the action
        /// </summary>
        public const string ACTION_NAMESPACE_SEPERATOR = "_";
    }
}