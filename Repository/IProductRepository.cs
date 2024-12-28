using ProductManagementApp.Models;

namespace ProductManagementApp.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public void CreateProduct(Product product, List<Product> existingProducts);
        public Product GetProductById(int id);
        public List<Product> UpdateProduct(Product product);
        public List<Product>? DeleteProduct(Product product);

    }
}
