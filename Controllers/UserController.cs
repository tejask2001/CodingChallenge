using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            try
            {
                var users = await _userService.GetAllUser();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var users = await _userService.GetUser(id);
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                return await _userService.AddUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("ReactPolicy")]
        [Route("Login")]
        public async Task<ActionResult<User>> Login(LoginDTO loginDTO)
        {
            try
            {
                var users = await _userService.Login(loginDTO);
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            try
            {
                return await _userService.UpdateUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var users = await _userService.RemoveUser(id);
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
