using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net.Sockets;
using TourManagementSystem.Application;
using TourManagementSystem.Application.Common;
using TourManagementSystem.Domain;

namespace TourManagementSystem.API
{
    [ApiController]
    [Route("api/users")]
    public class UserController:ControllerBase
    {

        UserService _userService;
       
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var savedUser= await _userService.AddUser(user);
            return Ok(savedUser);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
           var user=await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUserById(int id,User user)
        {
            var updatedUser = await _userService.UpdateUser(id,user);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var deletedUser=await _userService.DeleteUser(id);
            if (!deletedUser)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
