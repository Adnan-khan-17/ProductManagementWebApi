using ProductManagementApp.Models;
using ProductManagementApp.Repository;

namespace ProductManagementApp.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) { }
        public void CreateProduct(Product product)
        {
            var products = _repository.GetProducts();
            product.Id = products.Count > 0 ? products[^1].Id + 1 : 1;
            _repository.CreateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            var deleteproduct = GetProductById(product.Id);
            if (deleteproduct != null)
            {
                _repository.DeleteProduct(deleteproduct);
            }
        }

        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {  
            
             return _repository.GetProducts();
             
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }
    }
}
