using System;
using EmailValidator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailValidatorController : ControllerBase
    {
        private readonly IEmailValidationService emailValidationService;

        public EmailValidatorController(IEmailValidationService emailValidationService)
        {
            this.emailValidationService = emailValidationService;
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return this.Ok("Email Validator API");
        }

        [HttpGet]
        [Route("ValidateEmailUsingRegex")]
        public IActionResult ValidateEmailUsingRegex(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException();
            }

            var isValidEmail = emailValidationService.ValidateEmailUsingRegex(emailAddress);

            return this.Ok(isValidEmail);
        }

        [HttpGet]
        [Route("ValidateEmailUsingMailAddress")]
        public IActionResult ValidateEmailUsingMailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException();
            }

            var isValidEmail = emailValidationService.ValidateEmailUsingMailAddress(emailAddress);

            return this.Ok(isValidEmail);
        }

        [HttpGet]
        [Route("ValidateEmailUsingAttribute")]
        public IActionResult ValidateEmailUsingAttribute(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException();
            }

            var isValidEmail = emailValidationService.ValidateEmailUsingAttribute(emailAddress);

            return this.Ok(isValidEmail);
        }
    }
}