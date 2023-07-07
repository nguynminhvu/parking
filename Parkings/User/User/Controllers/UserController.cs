using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Authentications;
using User.Model.User;
using User.Service.Interface;
using System.Web;
using System.Net.NetworkInformation;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private Authentication _authen;
        private IUserService _service;

        public UserController(IUserService userService, Authentication authentication) {
            _authen = authentication;
            _service=userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> AuthenticationUser(UserLogin userLogin)
        {
            try
            {
                ResponseClient userResponse = (ResponseClient)await _service.LoginCheck(userLogin.Username, userLogin.Password);
                if (userResponse != null){
                    DTO.User user =(DTO.User) userResponse.Data;
                    string token = _authen.GeneratorToken(user);
                    return Ok((new JsonResult(new { Token = token })).Value) ;
                }
                return BadRequest(userResponse);
            }
            catch
            {
                return BadRequest("Can't working");
            }
        }

        [HttpGet]
     //   [Authorize]
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

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> AddUser( UserRequest userRequest)
        {
            try
            {
                return Ok(await _service.Add(userRequest));
            }
            catch
            {
                return BadRequest("Can't create user");
            }
        }

        
        [HttpPut]
        [Route("UpdateUser")]
        [Authorize]
        public async Task<IActionResult> UpdateUser( UserUpdate user )
        {
            try
            {
                return Ok(await _service.Update(user));
            }
            catch
            {
                return BadRequest("Can't update user");
            }
        }
    }
}
