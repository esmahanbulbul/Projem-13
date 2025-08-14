using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new()
        {
            new Product{Id= 1, Name="Product1", Category="Category1", Price=15.5m},
            new Product{Id= 2, Name="Product2", Category="Category2", Price=25.5m}
        };

        private static int _id = 3;

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }


        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            var product = _products.Find(p => p.Id == id);
            return product;
        }

        [HttpPost]
        public void CreateProduct(Product product)
        {
            product.Id = _id;
            _id++;
            _products.Add(product);
        }

        [HttpPut("{id}")]
        public void UpdateAProduct(Product product, int id)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;

        }


        [HttpDelete("{id}")]
        public void DeleteAProduct(int id)
        {
            int index = _products.FindIndex(p => p.Id == id);
            _products.RemoveAt(index);
        }


    }
}
