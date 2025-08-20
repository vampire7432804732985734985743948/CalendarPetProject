using CalendarPetProject.Data;
using CalendarPetProject.Models;
using CalendarPetProject.ViewModels.CustomerData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CalendarPetProject.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class DataRetrieveController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;

        public DataRetrieveController(SignInManager<Users> signInManager, UserManager<Users> userManager, AppDbContext appDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _appDbContext.Users.ToListAsync();

            if (users.Count == 0)
                return NotFound("No users found");

            return Ok(users);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user == null)
                return NotFound("User not found");

            var bodyProperties = await _appDbContext.CustomerBodyParameters
                .FirstOrDefaultAsync(b => b.UserId == id);

            if (bodyProperties == null)
            {
                return NotFound("Body parameters of selected user not found");
            }
            return Ok(new UserAccountData(user, bodyProperties));
        }
    }
}