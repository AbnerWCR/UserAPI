using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.API.ViewModels;
using User.Domain.Interfaces.Services;
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

                    var result = await _userService.Create(user);
                    var uri = new Uri($"api/[controller]/{result.Id}", UriKind.RelativeOrAbsolute);

                    return ResultCreated(uri, "User created", result);
                }

                return ResultNotFound("User not found");
            }
            catch (Exception ex)
            {
                return ResultInternalError(ex.Message);
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
                    return ResultOk("User updated", result);
                }

                return ResultNotFound("User not found");
            }
            catch (Exception ex)
            {
                return ResultInternalError(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == null)
                    return ResultNotFound("User not found");

                await _userService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return ResultInternalError(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.Get();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ResultInternalError(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _userService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ResultInternalError(ex.Message);
            }
        }
    }
}
