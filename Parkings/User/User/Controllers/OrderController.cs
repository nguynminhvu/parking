using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Model.Order;
using User.Service.Interface;
using User.Model.User;
namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;

        public OrderController(IOrderService order)
        {
            _service = order;
        }

        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> OrderBooking(OrderRequest order)
        {
            try
            {
                return Ok(await _service.Booking(order));

            }catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CheckIn")]
        public async Task<IActionResult> CheckIn(Guid idOrder)
        {
            try
            {

                return await _service.CheckIn(idOrder)?Ok("success"):BadRequest("Your action not support");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CheckOut")]
        public async Task<IActionResult> CheckOut(Guid idOrder)
        {
            try
            {

                return await _service.CheckOut(idOrder)? Ok("success") : BadRequest("Your action not support");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
