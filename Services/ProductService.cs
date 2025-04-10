using CRUD_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_API.Services
{
    public class ProductService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 799.99 },
            new Product { Id = 2, Name = "Smartphone", Price = 599.99 }
        };

        public List<Product> GetAll() => _products;

        public Product GetById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public Product Add(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            return product;
        }

        public bool Update(int id, Product updatedProduct)
        {
            var existingProduct = GetById(id);
            if (existingProduct == null) return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
