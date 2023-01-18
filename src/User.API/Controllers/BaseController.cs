using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using User.API.ViewModels;
using User.Domain.DTOs;
using User.Domain.Entities;
using User.Domain.Interfaces;
using User.Infra.CrossCutting.Messages;

namespace User.API.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        private readonly IBaseService<ErrorDTO, Error> _errorService;

        public BaseController(IBaseService<ErrorDTO, Error> errorService)
        {
            _errorService = errorService;
        }

        protected IActionResult ResultOk(string message, dynamic data)
        {
            var resultVm = new ResultViewModel(message, true, data);
            var jsonObj = JsonConvert.SerializeObject(resultVm);
            return Ok(jsonObj);
        }

        protected IActionResult ResultCreated(Uri uri, string message, dynamic data)
        {
            var resultVm = new ResultViewModel(message, true, data);
            return Created(uri, resultVm.ToJson());
        }

        protected IActionResult ResultNotFound(string message)
        {
            var resultVm = new ResultViewModel
            {
                Message = message,
                Success = false
            };

            return NotFound(resultVm.ToJson());
        }

        protected IActionResult ResultInternalError(string message)
        {
            var resultVm = new ResultViewModel
            {
                Message = message,
                Success = false
            };

            
            return StatusCode(500, resultVm.ToJson());
        }

        protected IActionResult ResultNotAuthorized(string message)
        {
            var resultVm = new ResultViewModel
            {
                Message = message,
                Success = false
            };

            return StatusCode(401, resultVm.ToJson());
        }

        protected async Task<IActionResult> SaveError(ErrorDTO errorDTO)
        {
            await _errorService.Create(errorDTO);

            return ResultInternalError(Messages.SystemError);
        }
    }
}
