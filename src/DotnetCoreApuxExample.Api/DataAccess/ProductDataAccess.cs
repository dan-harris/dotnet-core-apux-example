using System.Collections.Generic;
using System.Linq;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.DataAccess
{
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly List<Product> _productList;

        public ProductDataAccess()
        {
            _productList = new List<Product> {
                new Product { Id = 1, Name = "Shower Power", Price = 10 },
                new Product { Id = 2, Name = "Pears", Price = 7 },
                new Product { Id = 3, Name = "A Dog", Price = 25 },
                new Product { Id = 4, Name = "Toilet Paper", Price = 5 },
                new Product { Id = 5, Name = "Peanut Butter", Price = 4 }
            };
        }

        public List<Product> GetAllProducts() => _productList;

        public Product GetProductById(int productId) => _productList.FirstOrDefault((Product product) => product.Id == productId);
    }
}