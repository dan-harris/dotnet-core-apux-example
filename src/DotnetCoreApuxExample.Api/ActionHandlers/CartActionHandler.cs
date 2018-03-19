using System.Collections.Generic;
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

        public ApuxActionResult AddProductAction(JToken data)
        {
            var productId = data.Value<int>();

            _cartDataAccess.AddProduct(productId);

            return new ApuxActionResult
            {
                Data = new JValue(true)
            };
        }

        public ApuxActionResult RemoveProductAction(JToken data)
        {
            var productId = data.Value<int>();

            var result = _cartDataAccess.RemoveProduct(productId);

            return new ApuxActionResult
            {
                Data = new JValue(result)
            };
        }

        public ApuxActionResult ListProductsAction()
        {

            var productList = _cartDataAccess.ListProductsInCart();

            return new ApuxActionResult
            {
                Data = JArray.FromObject(productList)
            };
        }

        public ApuxActionResult GetProductTotalPrice()
        {

            var totalPrice = _cartDataAccess.GetProductTotalPrice();

            return new ApuxActionResult
            {
                Data = new JValue(totalPrice)
            };
        }

    }
}