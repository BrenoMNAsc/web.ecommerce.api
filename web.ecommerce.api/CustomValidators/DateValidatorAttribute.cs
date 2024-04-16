using System.ComponentModel.DataAnnotations;

namespace web.ecommerce.api.CustomValidators
{
    public class DateValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Order Date can't be blank!");
            } 
            else
            {
                DateTime date = (DateTime)value;
                if(date.Year < 2000)
                {
                    return new ValidationResult("Minimum year allowed is 2000!");
                } else return ValidationResult.Success;
            }
        }
    }
}
