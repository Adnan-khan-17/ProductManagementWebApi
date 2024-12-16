using Newtonsoft.Json;
using ProductManagementApp.Interfaces;
using ProductManagementApp.Models;

namespace ProductManagementApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private string filepath = "data.json";
        public void CreateProducts(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented); 
            File.WriteAllText(filepath, json);
        }

        public List<Product> GetProducts()
        {
            if (!File.Exists(filepath))
            {
                return [];
            }
            var json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<Product>>(json);

        }

    }
}
    