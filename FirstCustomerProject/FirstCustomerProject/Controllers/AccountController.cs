using FirstCustomerProject.DTO;
using FirstCustomerProject.NewFolder2;
using Microsoft.AspNetCore.Mvc;

namespace FirstCustomerProject.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountServices)
        {
            _accountService = accountServices;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDTOs payload)
        {
            var response = _accountService.RegisterAsync(payload);
            return Ok(response);
        }
    }
}
