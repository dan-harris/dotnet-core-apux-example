using System.Collections.Generic;
using System.Linq;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.DataAccess
{
    public interface ICartDataAccess
    {

        /// <summary>
        /// Add a Product to the Cart
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(int productId);

        /// <summary>
        /// Remove a Product from the cart
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool RemoveProduct(int productId);

        /// <summary>
        /// List all Products in the cart
        /// </summary>
        /// <returns></returns>
        List<Product> ListProductsInCart();

        /// <summary>
        /// Get the total (summation) price of all Products in Cart
        /// </summary>
        /// <returns></returns>
        int GetProductTotalPrice();

    }
}