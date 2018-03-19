using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.DataAccess
{
    public interface IProductDataAccess
    {
        /// <summary>
        /// Get a list of all Products that exist
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Get a Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProductById(int productId);
    }
}