using System.Collections.Generic;
using DotnetCoreApuxExample.Api.DataAccess;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public class ProductActionHandler : IProductActionHandler
    {

        private readonly IProductDataAccess _productDataAccess;

        public ProductActionHandler(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public ApuxActionResult GetAll()
        {
            var productList = _productDataAccess.GetAllProducts();

            return new ApuxActionResult
            {
                Data = JArray.FromObject(productList)
            };
        }

        public ApuxActionResult GetById(JToken data)
        {
            var productId = data.Value<int>();

            var product = _productDataAccess.GetProductById(productId);

            return new ApuxActionResult
            {
                Data = JObject.FromObject(product)
            };
        }

    }
}