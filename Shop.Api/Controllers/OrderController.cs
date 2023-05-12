using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Repository;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(Context context)
        {
            _orderRepository = new OrderRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderRepository.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderModel order)
        {
            await _orderRepository.Add(order);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderModel order)
        {
            await _orderRepository.Update(order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderRepository.RemoveById(id);
            return Ok();
        }
    }
}