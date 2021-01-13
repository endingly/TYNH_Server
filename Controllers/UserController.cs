using TYNH_server.Models;
using TYNH_server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TYNH_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService UserService)
        {
            _userService = UserService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Remove(User.id);

            return NoContent();
        }
    }
}