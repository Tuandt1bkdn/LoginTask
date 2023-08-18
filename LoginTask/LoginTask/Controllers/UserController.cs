using Dapper;
using LoginTask.Service;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.SqlClient;
using LoginTask.Models;

namespace LoginTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return View(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Json(user);
        }
        /*[HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            await _userService.Create(model);
            return Ok(new { message = "User created" });
        }*/
        
    }
    
}
