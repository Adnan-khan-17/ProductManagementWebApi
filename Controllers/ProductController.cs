using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Repository;
using ProductManagementApp.Services;

namespace ProductManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("id")]
        public IActionResult GetProduct(int id)
        { 
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.CreateProduct(newProduct);
            return Ok();
        }

        [HttpPut] 
        public ActionResult Put([FromBody] Product updatedProduct) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var products = _productService.UpdateProduct(updatedProduct);
            return Ok(products);
        }

        [HttpDelete]
        public ActionResult Delete(Product product)
        {
            var products = _productService.DeleteProduct(product);
            return Ok(products); 
        }

    }
}
