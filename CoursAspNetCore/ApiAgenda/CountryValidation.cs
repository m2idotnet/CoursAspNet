using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiAgenda
{
    public class CountryValidation : ValidationAttribute
    {
        public string AllowedCountry { get; set; }
        public string AllowdedCountries { get; set; }
        public string ErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] pays = AllowdedCountries.ToString().Split(',');
            if(AllowedCountry == value.ToString() || pays.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }       
    }

    public class TelePhoneValidation : ValidationAttribute
    {
        public string pattern { get;  set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex r = new Regex(@"");
            if(r.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Error telephone");
            }
         }
    }
}
