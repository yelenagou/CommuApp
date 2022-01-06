using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
   
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        //api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        //api/user/1
         [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}