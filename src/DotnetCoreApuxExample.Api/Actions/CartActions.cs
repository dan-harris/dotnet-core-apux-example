using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.Actions
{

    /// <summary>
    /// List of Actions for this Apux Action namespace
    /// </summary>
    public class CartActionsList
    {
        public const string LIST_PRODUCTS = "LIST_PRODUCTS";
        public const string ADD_PRODUCT = "ADD_PRODUCT";
        public const string REMOVE_PRODUCT = "REMOVE_PRODUCT";
        public const string GET_TOTAL_PRICE = "GET_TOTAL_PRICE";
    }

    /// <summary>
    /// Implements Actions for this Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class CartActions : IApuxAction
    {

        private readonly IAppErrorActionHandler _appErrorActionHandler;
        private readonly ICartActionHandler _cartActionHandler;

        public CartActions(
            IAppErrorActionHandler appErrorActionHandler,
            ICartActionHandler cartActionHandler
            )
        {
            _appErrorActionHandler = appErrorActionHandler;
            _cartActionHandler = cartActionHandler;
        }

        public ApuxActionResult executeAction(ApuxActionRequest actionRequest)
        {

            var result = _appErrorActionHandler.UnknownAction();

            switch (actionRequest.Action)
            {
                case CartActionsList.LIST_PRODUCTS:
                    {
                        result = _cartActionHandler.ListProductsAction();
                    }
                    break;

                case CartActionsList.ADD_PRODUCT:
                    {
                        result = _cartActionHandler.AddProductAction(actionRequest.Data);
                    }
                    break;

                case CartActionsList.REMOVE_PRODUCT:
                    {
                        result = _cartActionHandler.RemoveProductAction(actionRequest.Data);
                    }
                    break;

                case CartActionsList.GET_TOTAL_PRICE:
                default:
                    {
                        result = _cartActionHandler.GetProductTotalPrice();
                    }
                    break;
            }

            return result;


        }

    }
}