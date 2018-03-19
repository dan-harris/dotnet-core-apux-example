using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.Actions
{
    public class AllActions : IApuxAction
    {


        private readonly IApuxAction _appErrorActions;
        private readonly IApuxAction _cartActions;
        private readonly IApuxAction _productActions;


        public AllActions(Func<string, IApuxAction> _actions)
        {
            _appErrorActions = _actions(Constants.ActionNamespace.APP);
            _cartActions = _actions(Constants.ActionNamespace.CART);
            _productActions = _actions(Constants.ActionNamespace.PRODUCT);
        }

        public ApuxActionResult executeAction(ApuxActionRequest actionRequest)
        {

            ApuxActionResult actionResult;

            // Get action namespace
            var actionNamespace = actionRequest.Action.Split(Constants.ACTION_NAMESPACE_SEPERATOR)[0];
            // Remove action namespace from action in request (means actions dont have to worry about their own namespace)
            actionRequest.Action = actionRequest.Action.Replace($"{actionNamespace}{Constants.ACTION_NAMESPACE_SEPERATOR}", "");

            switch (actionNamespace)
            {
                // App error actions
                case Constants.ActionNamespace.APP:
                    {
                        actionResult = _appErrorActions.executeAction(actionRequest);
                    }
                    break;

                // Cart actions
                case Constants.ActionNamespace.CART:
                    {
                        actionResult = _cartActions.executeAction(actionRequest);
                    }
                    break;

                // Product actions
                case Constants.ActionNamespace.PRODUCT:
                    {
                        actionResult = _productActions.executeAction(actionRequest);
                    }
                    break;

                // Default Action (return App Error Unknown Action)
                default:
                    {
                        actionResult = _appErrorActions.executeAction(actionRequest);
                    }
                    break;
            }

            return actionResult;

        }

    }
}