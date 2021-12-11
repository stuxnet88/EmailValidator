namespace EmailValidator.Interfaces
{
    public interface IEmailValidationService
    {
        string ValidateEmailUsingRegex(string emailAddress);

        string ValidateEmailUsingMailAddress(string emailaddress);

        string ValidateEmailUsingAttribute(string emailaddress);
    }
}
