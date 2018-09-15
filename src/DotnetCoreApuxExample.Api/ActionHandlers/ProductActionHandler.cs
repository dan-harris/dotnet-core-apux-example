using Apux;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.DataAccess;
using DotnetCoreApuxExample.Api.Models;
using System.Collections.Generic;

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

        public ApuxActionResultBase GetById(GetByIdAction action)
        {

            var product = _productDataAccess.GetProductById(action.Payload);

            if (product == null) return new ApuxActionResultBase(new ApuxError(ApuxError.ErrorType.ERROR, "Could not find a product with the specified id."));
            else return new ApuxActionResult<Product>(product);
        }

        public ApuxActionResult<Product> Update(UpdateAction action)
        {
            var product = _productDataAccess.Update(action.Payload);

            return new ApuxActionResult<Product>(product);
        }
    }
}