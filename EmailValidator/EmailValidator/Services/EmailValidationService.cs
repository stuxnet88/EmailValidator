using EmailValidator.constants;
using EmailValidator.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EmailValidator.Services
{

    public class EmailValidationService : IEmailValidationService
    {
        public string ValidateEmailUsingRegex(string emailAddress)
        {
            var regexPattern = new Regex(CommonConfig.EmailRegexPattern);

            return GetResponse(regexPattern.IsMatch(emailAddress));
        }

        public string ValidateEmailUsingMailAddress(string emailAddress)
        {

            try
            {
                MailAddress mailAddress = new MailAddress(emailAddress);

                bool isValid = mailAddress.Address == emailAddress;

                return GetResponse(isValid);
            }
            catch (FormatException)
            {
                return GetResponse(false);
            }
        }

        public string ValidateEmailUsingAttribute(string emailAddress)
        {

            bool isValid = new EmailAddressAttribute().IsValid(emailAddress);

            return GetResponse(isValid);

        }

        private static string GetResponse(bool isValid)
        {
            return isValid ? "Email address is valid" : "Email address is not valid";
        }
    }
}
