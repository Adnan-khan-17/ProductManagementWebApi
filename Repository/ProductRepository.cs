using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using ProductManagementApp.Models;
using System.IO;

namespace ProductManagementApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        public string filepath = "C:\\Users\\HP\\OneDrive\\Desktop\\csharpprojects\\ProductManagementApp\\data.json";

        

        public List<Product> GetProducts()
        {
            if (!File.Exists(filepath))
            {
                return [];
            }
            var json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<Product>>(json);

        }
        public void CreateProduct(Product product)
        {
            var json = JsonConvert.SerializeObject(product, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

        public void DeleteProduct(Product product)
        {
            var products = GetProducts();
            products.Remove(product);
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

        public Product GetProductById(int id)
        {
            var products = GetProducts();
            return products.Find(x => x.Id == id);
        }
        

        public void UpdateProduct(Product product)
        {
            var products = GetProducts();
            var updateProduct = products.Find(x=>x.Id == product.Id);
            if (updateProduct != null)
            {
                updateProduct = product;
                
            }
        }
    }
}
    