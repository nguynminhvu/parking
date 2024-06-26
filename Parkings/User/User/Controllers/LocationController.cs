﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.DTO;
using User.Service.Interface;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationService _service;

        public LocationController(ILocationService location)
        {
            _service = location;
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(string name, string iframe)
        {
            try
            {
                Location location = new Location {
                Id=Guid.NewGuid(),
                Name=name,
                Iframe=iframe
                };
                await _service.CreateLocation(location);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var rs =await _service.GetAll();
                return rs != null ? Ok(rs) : BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetLocationById")]
        public async Task<IActionResult> GetLocationById(Guid idLocation)
        {
            try
            {
                var rs =await _service.GetLocationById(idLocation);
                return rs!=null? Ok(rs) : BadRequest(); 
            }catch (Exception ex) { 
                return BadRequest(ex.Message);  
            }
        }
    }
}
