using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Actions
{

    /// <summary>
    /// Actions for Apux Action namespace
    /// </summary>
    public class CartActions
    {

        public const string LIST_PRODUCTS = "CART_LIST_PRODUCTS";
        public const string ADD_PRODUCT = "CART_ADD_PRODUCT";
        public const string REMOVE_PRODUCT = "CART_REMOVE_PRODUCT";
        public const string GET_TOTAL_PRICE = "CART_GET_TOTAL_PRICE";

    }

    public class ListProductsAction : ApuxAction<object>
    {
        public ListProductsAction() : base(CartActions.LIST_PRODUCTS) { }
    }

    public class AddProductAction : ApuxAction<int>
    {
        public AddProductAction(JToken payload) : base(CartActions.ADD_PRODUCT, payload) { }
    }

    public class RemoveProductAction : ApuxAction<int>
    {
        public RemoveProductAction(JToken payload) : base(CartActions.REMOVE_PRODUCT, payload) { }
    }

    public class GetTotalPriceAction : ApuxAction<int>
    {
        public GetTotalPriceAction() : base(CartActions.GET_TOTAL_PRICE) { }
    }
}