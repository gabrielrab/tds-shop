using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Repository;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/orderLine")]
    public class OrderLineController : ControllerBase
    {
        private readonly OrderLineRepository _orderLineRepository;

        public OrderLineController(Context context)
        {
            _orderLineRepository = new OrderLineRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orderLines = await _orderLineRepository.GetAll();
            return Ok(orderLines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderLine = await _orderLineRepository.GetById(id);
            return Ok(orderLine);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderLineModel orderLine)
        {
            await _orderLineRepository.Add(orderLine);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderLineModel orderLine)
        {
            await _orderLineRepository.Update(orderLine);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderLineRepository.RemoveById(id);
            return Ok();
        }
    }
}