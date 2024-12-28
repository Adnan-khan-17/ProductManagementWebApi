using ProductManagementApp.Models;

namespace ProductManagementApp.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();

        public void CreateProduct(Product product);

        public Product GetProductById(int id);
        public List<Product> UpdateProduct(Product product);
        public List<Product>? DeleteProduct(Product product);
    }
}
