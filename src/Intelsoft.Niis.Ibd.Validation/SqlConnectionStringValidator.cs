using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Intelsoft.Niis.Ibd.Validation
{
    public class SqlConnectionStringValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object item, ValidationContext validationContext)
        {
            if (!(item is string input))
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName),
                    new[] {validationContext.MemberName});

            try
            {
                var connectionString = new SqlConnectionStringBuilder(input);
            }
            catch (Exception)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName),
                    new[] {validationContext.MemberName});
            }

            return ValidationResult.Success;
        }
    }
}