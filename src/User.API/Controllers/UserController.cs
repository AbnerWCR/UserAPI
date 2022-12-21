using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.API.ViewModels;
using User.Domain.Interfaces.Services;
using User.Infra.CrossCutting.Messages;
using User.Services.DTOs;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel createUserVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<UserDTO>(createUserVm);

                    var userCreated = await _userService.Create(user);

                    var uri = new Uri($"api/user/{userCreated.Id}", UriKind.RelativeOrAbsolute);

                    return ResultCreated(uri, Messages.UserCreated, userCreated);
                }

                return ResultNotFound(Messages.UserNotFound);
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<UserDTO>(updateUserVm);

                    var result = await _userService.Update(user);
                    return ResultOk(Messages.UserUpdated, result);
                }

                return ResultNotFound(Messages.UserNotFound);
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == null)
                    return ResultNotFound(Messages.UserNotFound);

                await _userService.Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.Get();

                return ResultOk(string.Empty, result);
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _userService.GetById(id);

                return ResultOk(string.Empty, result);
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }
        }

        [HttpGet("{email}/by-email")]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                var result = await _userService.GetByEmail(email);

                return ResultOk(string.Empty, result);
            }
            catch (Exception)
            {
                return ResultInternalError(Messages.SystemError);
            }
        }
    }
}
