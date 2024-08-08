using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.data;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;

        public UsersController(IUsers context)
        {
            _users = context;
        }

        // GET: api/Users
        [Route("/Users/GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
         return await _users.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
          return await _users.GetUsersById(id);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            var updateUsers = await _users.UpdateUsers(id, users);
            return Ok(updateUsers);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
         var newUser= await _users.CreateUsers(users);
            return Ok(newUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var deletedUsers = _users.DeleteUsers(id);
            return Ok(deletedUsers);
        }
    }
}
