using System.Text.RegularExpressions;
using System.Windows.Controls;
using ValidatorSample;

namespace _15_Validierung
{
    public class LoginPasswordValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string inputString = value == null ? string.Empty : value.ToString().Trim();

            if (string.IsNullOrEmpty(inputString))
                return new ValidationResult(false, "Passwort darf nicht leer sein.");

            PasswordScore score = CheckStrength(inputString);
            if (score < (PasswordScore)3)
            {
                return new ValidationResult(false, $"Das Password ist {score}");
            }

            return ValidationResult.ValidResult;
        }

        public static PasswordScore CheckStrength(string password)
        {
            int score = 1;

            if (password.Length < 1)
                return PasswordScore.Leer;
            if (password.Length < 4)
                return PasswordScore.SehrSchwach;
            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }
    }
}