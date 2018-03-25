using System.Collections.Generic;
using Apux;
using DotnetCoreApuxExample.Api.Actions;
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

        public ApuxActionResult<List<Product>> GetAll(GetAllAction action)
        {
            var productList = _productDataAccess.GetAllProducts();

            return new ApuxActionResult<List<Product>>(productList);
        }

        public IApuxActionResult GetById(GetByIdAction action)
        {

            var product = _productDataAccess.GetProductById(action.Payload);

            if (product == null) return new ApuxActionResult<JToken>(new InternalErrorAction());
            else return new ApuxActionResult<Product>(product);
        }

        public ApuxActionResult<Product> Update(UpdateAction action)
        {
            var product = _productDataAccess.Update(action.Payload);

            return new ApuxActionResult<Product>(product);
        }

    }
}