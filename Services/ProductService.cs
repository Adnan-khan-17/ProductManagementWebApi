using ProductManagementApp.Models;
using ProductManagementApp.Repository;

namespace ProductManagementApp.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }
        public void CreateProduct(Product product)
        {
            var existingProducts = _repository.GetProducts();
            product.Id = existingProducts.Count > 0 ? existingProducts[^1].Id + 1 : 1;
            _repository.CreateProduct(product, existingProducts);
        }

        public List<Product>? DeleteProduct(Product product)
        {
            var deleteproduct = _repository.GetProductById(product.Id);
            if (deleteproduct != null)
            {
               return _repository.DeleteProduct(deleteproduct);
            }
            return null;
        }

        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {  
            
             return _repository.GetProducts();
             
        }

        public List<Product> UpdateProduct(Product product)
        {
           return _repository.UpdateProduct(product);
        }
    }
}
