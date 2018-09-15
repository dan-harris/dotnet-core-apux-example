using Apux;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Actions;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{

    /// <summary>
    /// Implements Actions for Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class CartActionDispatcher : IApuxActionDispatcher
    {
        private readonly IAppErrorActionHandler _appErrorActionHandler;
        private readonly ICartActionHandler _cartActionHandler;

        public CartActionDispatcher(IAppErrorActionHandler appErrorActionHandler, ICartActionHandler cartActionHandler)
        {
            _appErrorActionHandler = appErrorActionHandler;
            _cartActionHandler = cartActionHandler;
        }

        public ApuxActionResultBase Dispatch(ApuxActionBase actionRequest)
        {
            switch (actionRequest.Type)
            {
                case CartActions.LIST_PRODUCTS:
                    return _cartActionHandler.ListProductsHandler(new ListProductsAction());
                case CartActions.ADD_PRODUCT:
                    return _cartActionHandler.AddProductHandler(new AddProductAction(actionRequest));
                case CartActions.REMOVE_PRODUCT:
                    return _cartActionHandler.RemoveProductHandler(new RemoveProductAction(actionRequest));
                case CartActions.GET_TOTAL_PRICE:
                    return _cartActionHandler.GetProductTotalPriceHandler(new GetTotalPriceAction());
                default:
                    return _appErrorActionHandler.UnknownActionHandler(new UnknownActionAction());
            }
        }
    }
}