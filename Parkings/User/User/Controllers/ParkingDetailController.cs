using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Service.Interface;
using User.Service.Interface;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingDetailController : ControllerBase
    {
        private IParkingDetailServices _service;

        public ParkingDetailController(IParkingDetailServices parkingService) {
            _service=parkingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch
            {
                return BadRequest();    
            }
        }


        [HttpGet]
        [Route("GetParkingDetailByIdParking")]
        public async Task<IActionResult> GetParkingDetailByIdParking(string? idParking)
        {
            try
            {
                var rs = await _service.GetParkingDetailByIdParking(Guid.Parse(idParking));
                return (rs != null) ? Ok(rs) : NotFound();
            }
            catch
            {
                return BadRequest();    
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetParkingDetailById([FromRoute]Guid id)
        {
            try
            {
                var rs = await _service.GetParkingDetailById(id.ToString());
                return rs != null ? Ok(rs) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
