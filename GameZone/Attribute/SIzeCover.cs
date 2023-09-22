using System.ComponentModel.DataAnnotations;
using GameZone.wwwroot.Settings;

namespace GameZone.Attribute
{
    public class SIzeCover : ValidationAttribute
    {
        private int _max; 
        public SIzeCover (int max)
        {
            _max = max; 
        }
        protected override ValidationResult?
    IsValid(object? value,
    ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
             
                if (file.Length > _max)
                {
                    return new ValidationResult($"max is{_max}");
                }

            }
            return ValidationResult.Success;
        }
    }
}
