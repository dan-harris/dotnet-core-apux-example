using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.DataAccess;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public class CartActionHandler : ICartActionHandler
    {

        private readonly ICartDataAccess _cartDataAccess;

        public CartActionHandler(ICartDataAccess cartDataAccess)
        {
            _cartDataAccess = cartDataAccess;
        }

        public ApuxActionResult<bool> AddProductHandler(AddProductAction action)
        {

            _cartDataAccess.AddProduct(action.Payload);

            return new ApuxActionResult<bool>(true);

        }

        public ApuxActionResult<bool> RemoveProductHandler(RemoveProductAction action)
        {
            var result = _cartDataAccess.RemoveProduct(action.Payload);

            return new ApuxActionResult<bool>(result);
        }

        public ApuxActionResult<List<Product>> ListProductsHandler(ListProductsAction action)
        {

            var productList = _cartDataAccess.ListProductsInCart();

            return new ApuxActionResult<List<Product>>(productList);
        }

        public ApuxActionResult<int> GetProductTotalPriceHandler(GetTotalPriceAction action)
        {

            var totalPrice = _cartDataAccess.GetProductTotalPrice();

            return new ApuxActionResult<int>(totalPrice);
        }

    }
}