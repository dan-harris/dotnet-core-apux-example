using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{

    /// <summary>
    /// Implements Actions for Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class CartActionDispatcher : IApuxActionDispatcher
    {

        private readonly IAppErrorActionHandler _appErrorActionHandler;
        private readonly ICartActionHandler _cartActionHandler;

        public CartActionDispatcher(
            IAppErrorActionHandler appErrorActionHandler,
            ICartActionHandler cartActionHandler
        )
        {
            _appErrorActionHandler = appErrorActionHandler;
            _cartActionHandler = cartActionHandler;
        }

        public IApuxActionResult Dispatch(ApuxAction<JToken> actionRequest)
        {


            switch (actionRequest.Type)
            {
                case CartActions.LIST_PRODUCTS:
                    {
                        return _cartActionHandler.ListProductsHandler(new ListProductsAction());
                    }

                case CartActions.ADD_PRODUCT:
                    {
                        return _cartActionHandler.AddProductHandler(new AddProductAction(actionRequest.Payload));
                    }

                case CartActions.REMOVE_PRODUCT:
                    {
                        return _cartActionHandler.RemoveProductHandler(new RemoveProductAction(actionRequest.Payload));
                    }

                case CartActions.GET_TOTAL_PRICE:
                    {
                        return _cartActionHandler.GetProductTotalPriceHandler(new GetTotalPriceAction());
                    }

                default:
                    {
                        return _appErrorActionHandler.UnknownActionHandler(new UnknownActionAction());
                    }
            }



        }

    }
}