using Apux;

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

    public class ListProductsAction : ApuxActionBase
    {
        public ListProductsAction() : base(CartActions.LIST_PRODUCTS) { }
    }

    public class AddProductAction : ApuxAction<int>
    {
        public AddProductAction(ApuxActionBase basePayload) : base(CartActions.ADD_PRODUCT, basePayload) { }
        public AddProductAction(int value) : base(CartActions.ADD_PRODUCT, value) { }
    }

    public class RemoveProductAction : ApuxAction<int>
    {
        public RemoveProductAction(ApuxActionBase basePayload) : base(CartActions.REMOVE_PRODUCT, basePayload) { }
        public RemoveProductAction(int value) : base(CartActions.REMOVE_PRODUCT, value) { }
    }

    public class GetTotalPriceAction : ApuxActionBase
    {
        public GetTotalPriceAction() : base(CartActions.GET_TOTAL_PRICE) { }
    }
}