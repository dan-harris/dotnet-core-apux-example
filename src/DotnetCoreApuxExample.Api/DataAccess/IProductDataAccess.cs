using DotnetCoreApuxExample.Api.Models;
using System.Collections.Generic;

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

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product Update(Product product);
    }
}