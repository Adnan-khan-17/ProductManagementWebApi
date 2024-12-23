using ProductManagementApp.Models;

namespace ProductManagementApp.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();

        public void CreateProduct(Product product);

        public Product GetProductById(int id);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
    }
}
