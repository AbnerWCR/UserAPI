using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;
using User.API.ViewModels;
using User.Domain.Interfaces.API;
using User.Domain.Interfaces.Services;
using User.Domain.VOs;
using User.Infra.CrossCutting.Exceptions;
using User.Infra.CrossCutting.Messages;
using User.Services.DTOs;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public AuthController(
            IConfiguration configuration,
            ITokenGenerator tokenGenerator,
            IUserService userService)
        {
            _tokenGenerator = tokenGenerator;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel loginVm)
        {
            string role = string.Empty;

            try
            {
                var userDto = await FindUser(loginVm.Login);
                var passwordVO = new Password(loginVm.Password);
                passwordVO.AddKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                if (loginVm.Login.ToLower() == userDto.Email.ToLower() && !passwordVO.CompareHash(userDto.PasswordHash, userDto.Id))
                    return ResultNotAuthorized(Messages.UnauthorizedUser);

                role = userDto.Role;
            }
            catch (DomainException domainEx)
            {
                return ResultNotFound(domainEx.Message);
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }

            return ResultOk(Messages.AuthenticatedUser, new
            {
                token = _tokenGenerator.GenerateToken(loginVm.Login, role),
                tokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
            });
        }

        private async Task<UserDTO> FindUser(string login)
        {
            var user = await _userService.GetByEmail(login);

            if (user == null)
                throw new DomainException(Messages.UserNotFound);

            return user;
        }
    }
}
