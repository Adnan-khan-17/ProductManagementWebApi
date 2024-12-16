using ProductManagementApp.Models;

namespace ProductManagementApp.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();

        public void CreateProducts(List<Product> products);
    }
}
