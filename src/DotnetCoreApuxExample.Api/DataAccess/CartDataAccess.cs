using System.Collections.Generic;
using System.Linq;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.DataAccess
{
    public class CartDataAccess : ICartDataAccess
    {
        private readonly IProductDataAccess _productDataAccess;
        private readonly List<Product> _productList;

        public CartDataAccess(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
            _productList = new List<Product>();
        }

        public void AddProduct(int productId) => _productList.Add(_productDataAccess.GetProductById(productId));

        public bool RemoveProduct(int productId) => _productList.RemoveAll((Product product) => product.Id == productId) > 0;

        public List<Product> ListProductsInCart() => _productList;

        public int GetProductTotalPrice() => _productList.Aggregate(0, (int acc, Product product) => acc + product.Price);

    }
}