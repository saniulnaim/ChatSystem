using Chat.Core.Services;
using Chat.Repository.Core.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Declaration & Construction
        private readonly IUserService iUserService;

        public UserController(IUserService iUserServiceParam)
        {
            iUserService = iUserServiceParam;
        }
        #endregion Declaration & Construction


        [HttpPost("Add")]
        public async Task<User> Add([FromBody] User obj) //Use DTO
        {
            obj.LoginStatus = true;
            var result = await iUserService.AddAsync(obj);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await iUserService.GetAllAsync();
            return result;
        }


        [HttpPost("Login")]
        public async Task<User> Login(string email)
        {
            var result = await iUserService.UpdateLoginStatus(email);
            return result;
        }

        [HttpPost("Logout")]
        public async Task<User> Logout(long id)
        {
            var user = await iUserService.FirstOrDefaultAsync(a => a.Id == id);
            var result = await iUserService.UpdateLogoutStatus(user.Email);
            return result;
        }
    }
}
