using System.Net.Mail;

namespace WarehouseOperative.Models.Validators
{
    public class StringValidator : Validator
    {
        #region Methods

        public static string EmailCheck(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            var trimmedEmail = value.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return "Incorrect email address";
            }
            try
            {
                var addr = new MailAddress(value);
                return string.Empty;
            }
            catch
            {
                return "Incorrect email address";
            }
        }

        public static string IsLenghtCorrect(string value, int length)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            if (value.Length > length)
            {
                return "Lenght is not correct!";
            }
            else
            {                
                return string.Empty;
            }
        }
        #endregion
    }
}
