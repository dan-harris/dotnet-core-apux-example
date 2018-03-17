using System.Collections.Generic;
using System.Linq;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.DataAccess
{
    public class CartDataAccess : ICartDataAccess
    {
        private readonly List<Product> _productList;

        public CartDataAccess()
        {
            _productList = new List<Product>();
        }

        public void AddProduct(Product product) => _productList.Add(product);

        public bool RemoveProduct(Product product) => _productList.Remove(product);

        public List<Product> ListProductsInCart() => _productList;

        public int GetProductTotalPrice() => _productList.Aggregate(0, (int acc, Product product) => acc + product.Price);

    }
}