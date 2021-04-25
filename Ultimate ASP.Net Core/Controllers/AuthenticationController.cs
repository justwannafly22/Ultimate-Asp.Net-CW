using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using Entities.DTO.User;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationManager _authManager;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationManager authManager, UserManager<User> userManager, ILoggerManager logger, IMapper mapper)
        {
            _authManager = authManager;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuth)
        {
            if(!await _authManager.ValidateUser(userForAuth))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authenticaton failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
        
    }
}
