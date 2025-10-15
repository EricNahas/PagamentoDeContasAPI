using System.ComponentModel.DataAnnotations;

namespace ProjetoDeliverIT.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CampoObrigatorioAttribute : ValidationAttribute
    {
        public CampoObrigatorioAttribute()
        {
            ErrorMessage = "O campo {0} é obrigatório.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (value == null)
                return new ValidationResult(string.Format(ErrorMessage!, context.DisplayName));

            switch (value)
            {
                case string s when string.IsNullOrWhiteSpace(s):
                    return new ValidationResult(string.Format(ErrorMessage!, context.DisplayName));

                case DateTimeOffset dt when dt == DateTimeOffset.MinValue:
                    return new ValidationResult(string.Format(ErrorMessage!, context.DisplayName));

                case DateTime d when d == DateTime.MinValue:
                    return new ValidationResult(string.Format(ErrorMessage!, context.DisplayName));

                case int i when i == 0:
                case long l when l == 0:
                case decimal dec when dec == 0:
                case double dbl when dbl == 0:
                    return new ValidationResult(string.Format(ErrorMessage!, context.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
