using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using ProductManagementApp.Models;
using System.Collections.Generic;
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
        public void CreateProduct(Product product, List<Product> existingProducts)
        {
            // Append new products to the existing list
            existingProducts.Add(product);
            var json = JsonConvert.SerializeObject(existingProducts, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

        public List<Product>? DeleteProduct(Product deleteproduct)
        {
            var products = GetProducts();
            products.RemoveAt(deleteproduct.Id - 1);

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filepath, json);
            return products;
        }

        public Product GetProductById(int id)
        {
            var products = GetProducts();
            return products.Find(x => x.Id == id);
        }
        

        public List<Product> UpdateProduct(Product product)
        {
            var products = GetProducts();
            var productIndex = products.FindIndex(x => x.Id == product.Id);
            if (productIndex == -1)
            {
                return null;
                
            }
            else
            {
                products[productIndex] = product;
            }

            var updatedJsonData = JsonConvert.SerializeObject(products, Formatting.Indented); 
            File.WriteAllText(filepath, updatedJsonData); 
            
            return products;

        }
    }
}
    