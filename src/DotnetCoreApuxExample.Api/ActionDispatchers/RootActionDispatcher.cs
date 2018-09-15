using Apux;
using System;

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

        public ApuxActionResultBase RootDispatch(ApuxActionBase actionRequest)
        {
            // Get action namespace
            var actionNamespace = actionRequest.Type.Split(Constants.ACTION_NAMESPACE_SEPERATOR)[0];

            // dispatch to child dispatchers using namespace
            ApuxActionResultBase result = Dispatch(actionNamespace, actionRequest);

            // recursively dispatch any returned actions (allows chaining of dispatch actions)
            if (result.Dispatch) result = RootDispatch(result);

            return result;
        }

        public ApuxActionResultBase Dispatch(string actionNamespace, ApuxActionBase action)
        {

            // set app error as default action dispatch
            ApuxActionResultBase result = _appErrorActions.Dispatch(action);

            switch (actionNamespace)
            {
                // App error actions
                case Constants.ActionNamespace.APP:
                    result = _appErrorActions.Dispatch(action);
                    break;
                // Cart actions
                case Constants.ActionNamespace.CART:
                    result = _cartActionDispatcher.Dispatch(action);
                    break;

                // Product actions
                case Constants.ActionNamespace.PRODUCT:
                    result = _productActions.Dispatch(action);
                    break;
            }

            return result;
        }
    }
}