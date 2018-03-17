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
            var product = data.ToObject<Product>();

            _cartDataAccess.AddProduct(product);

            return new ApuxActionResult
            {
                Data = JObject.FromObject(product)
            };
        }

        public ApuxActionResult RemoveProductAction(JToken data)
        {
            var product = data.ToObject<Product>();

            _cartDataAccess.RemoveProduct(product);

            return new ApuxActionResult
            {
                Data = { }
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

    }
}