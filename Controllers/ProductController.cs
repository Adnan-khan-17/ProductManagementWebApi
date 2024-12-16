using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Interfaces;
using ProductManagementApp.Models;

namespace ProductManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct) 
        { var products = _productRepository.GetProducts(); 
            newProduct.Id = products.Count > 0 ? products[^1].Id + 1 : 1;
            products.Add(newProduct);
            _productRepository.CreateProducts(products); 
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")] 
        public ActionResult Put(int id, [FromBody] Product updatedProduct) 
        {
            var products = _productRepository.GetProducts();
            var productIndex = products.FindIndex(p => p.Id == id);
            if (productIndex == -1)
            {
                return NotFound();
            }
            products[productIndex] = updatedProduct;
            _productRepository.CreateProducts(products);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var products = _productRepository.GetProducts();
            var product = products.Find(p => p.Id == id); 
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            _productRepository.CreateProducts(products);
            return NoContent(); 
        }

    }
}
