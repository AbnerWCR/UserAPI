using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using User.API.ViewModels;

namespace User.API.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
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
    }
}
