using Application.DTOS;
using Application.Services;
using Core.Common;
using Core.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<AuthenticationResult>>> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.CheckLoginAsync(request.Username, request.Password);

            if (result != null)
            {
                return ApiResponseFactory.Success(result, "登录成功");
            }
            else
            {
                return ApiResponseFactory.Failure<AuthenticationResult>("登录失败");
            }
        }

    }
}
