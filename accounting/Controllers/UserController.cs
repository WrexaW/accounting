using accounting.entities;
using accounting.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IPackageService _packageService;
        private IUserService _userService;

        public UserController(IPackageService packageService, IUserService userService)
        {
            _packageService = packageService;
            _userService = userService;
        }
        [HttpGet]
        public List<UserEntity> GetUsers() => _userService.GetAll();
        [HttpPost]
        public UserEntity CreateUser(UserEntity user) => _userService.Create(user);
        [HttpGet("remain/{userId}")]
        public int GetRemain(int userId) =>_userService.RemainDays(userId);
        [HttpPost("buy/{userId}")]
        public UserPackageEntity Buy(int userId, int packageId, string transaction = "") => _packageService.Buy(userId, packageId, transaction);

    }
}
