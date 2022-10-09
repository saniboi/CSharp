using System.Windows.Controls;

namespace _15_Validierung
{
    public class LoginUserValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string inputString = value == null ? string.Empty : value.ToString().Trim();

            if (string.IsNullOrEmpty(inputString))
            {
                return new ValidationResult(false, "Bitte User eingeben");
            }

            if (inputString.Length > 8)
            {
                return new ValidationResult(false, "User kann maximal 8 Zeichen lang sein.");
            }

            return ValidationResult.ValidResult; // Anstatt dem Konstruktor von ValidationResult das Resultat true zu übergeben,
                                                 // um eine positive Überprüfung zu signalisieren, können sie auch die
                                                 // statische Eigenschaft ValidationRule.ValidResult zurückliefern.
        }
    }
}