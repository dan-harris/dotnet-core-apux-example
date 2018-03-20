using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{
    public class RootActionDispatcher : IApuxActionRootDispatcher
    {


        private readonly IApuxActionDispatcher _appErrorActions;
        private readonly IApuxActionDispatcher _cartActionDispatcher;
        private readonly IApuxActionDispatcher _productActions;


        public RootActionDispatcher(Func<string, IApuxActionDispatcher> _actions)
        {
            _appErrorActions = _actions(Constants.ActionNamespace.APP);
            _cartActionDispatcher = _actions(Constants.ActionNamespace.CART);
            _productActions = _actions(Constants.ActionNamespace.PRODUCT);
        }

        public IApuxActionResult Dispatch(IApuxAction<Object> actionRequest)
        {

            // Get action namespace
            var actionNamespace = actionRequest.Type.Split(Constants.ACTION_NAMESPACE_SEPERATOR)[0];
            // Remove action namespace from action in request (means actions dont have to worry about their own namespace)
            var localAction = actionRequest.Type.Replace($"{actionNamespace}{Constants.ACTION_NAMESPACE_SEPERATOR}", "");
            // instantiate a new action for the request
            var action = new ApuxAction<JToken>(localAction, JToken.FromObject(actionRequest.Payload));

            switch (actionNamespace)
            {
                // App error actions
                case Constants.ActionNamespace.APP:
                    {
                        return _appErrorActions.Dispatch(action);
                    }

                // Cart actions
                case Constants.ActionNamespace.CART:
                    {
                        return _cartActionDispatcher.Dispatch(action);
                    }

                // Product actions
                case Constants.ActionNamespace.PRODUCT:
                    {
                        return _productActions.Dispatch(action);
                    }

                // Default Action (return App Error Unknown Action)
                default:
                    {
                        return _appErrorActions.Dispatch(action);
                    }
            }

        }

    }
}