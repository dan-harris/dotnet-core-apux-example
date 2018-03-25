using System;
using System.Collections.Generic;
using Apux;
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

        public IApuxActionResult RootDispatch(IApuxAction actionRequest)
        {

            // Get action namespace
            var actionNamespace = actionRequest.Type.Split(Constants.ACTION_NAMESPACE_SEPERATOR)[0];
            // instantiate a new action for the request
            var action = new ApuxAction<JToken>(actionRequest.Type, JToken.FromObject(actionRequest.BasePayload));

            // dispatch to child dispatchers using namespace
            IApuxActionResult result = Dispatch(actionNamespace, action);

            // recursively dispatch any returned actions (allows chaining of dispatch actions)
            if (result.Dispatch) result = RootDispatch(result);

            return result;
        }

        public IApuxActionResult Dispatch(string actionNamespace, ApuxAction<JToken> action)
        {

            // set app error as default action dispatch
            IApuxActionResult result = _appErrorActions.Dispatch(action);

            switch (actionNamespace)
            {
                // App error actions
                case Constants.ActionNamespace.APP:
                    {
                        result = _appErrorActions.Dispatch(action);
                    }
                    break;

                // Cart actions
                case Constants.ActionNamespace.CART:
                    {
                        result = _cartActionDispatcher.Dispatch(action);
                    }
                    break;

                // Product actions
                case Constants.ActionNamespace.PRODUCT:
                    {
                        result = _productActions.Dispatch(action);
                    }
                    break;
            }

            return result;

        }
    }
}