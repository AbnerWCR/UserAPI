﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using User.API.ViewModels;
using User.Domain.Interfaces.API;
using User.Domain.Interfaces.Services;
using User.Infra.CrossCutting.Exceptions;
using User.Infra.CrossCutting.Helpers;
using User.Services.DTOs;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly HelperPassword _helperPassword;
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public AuthController(
            HelperPassword helperPassword,
            IConfiguration configuration,
            ITokenGenerator tokenGenerator, 
            IUserService userService)
        {
            _helperPassword = helperPassword;
            _tokenGenerator = tokenGenerator;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel loginVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ResultNotAuthorized("User not authorized.");

                var userDto = await FindUser(loginVm.Login);

                if (loginVm.Login.ToLower() == userDto.Email.ToLower() && !_helperPassword.CompareHash(loginVm.Password, userDto.Password, userDto.Id))
                    return ResultNotAuthorized("User not authorized.");
            }
            catch (DomainException domainEx)
            {
                return ResultNotAuthorized(domainEx.Message);                
            }
            catch (Exception ex)
            {
                return ResultInternalError(ex.Message);
            }

            return ResultOk("Authenticaded user.", new
            {
                Token = _tokenGenerator.GenerateToken(loginVm.Login),
                TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
            });
        }

        private async Task<UserDTO> FindUser(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new DomainException("login can't be null or empty");

            var user = await _userService.GetByEmail(login);

            if (user == null)
                throw new DomainException("user not founded");

            return user;
        }
    }
}