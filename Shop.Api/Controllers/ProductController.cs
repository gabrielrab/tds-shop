using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Repository;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(Context context)
        {
            _productRepository = new ProductRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductModel product)
        {
            await _productRepository.Add(product);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductModel product)
        {
            await _productRepository.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.RemoveById(id);
            return Ok();
        }
    }
}