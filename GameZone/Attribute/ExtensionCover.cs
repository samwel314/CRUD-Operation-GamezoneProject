using GameZone.wwwroot.Settings;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Attribute
{
    public class ExtensionCover : ValidationAttribute
    {
        private readonly string _allowedExtension;
        public ExtensionCover(string _allowedExtension)
        {
            this._allowedExtension = _allowedExtension;
        }
        
        protected override ValidationResult?
            IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var Extension = Path.GetExtension(file.FileName);

                var isvalid = StData.
                    AllowedExte.Split(",").Contains(Extension
                    , StringComparer.OrdinalIgnoreCase);
                if (!isvalid)
                {
                    return new ValidationResult($"Only{StData.AllowedExte}");

                }

            }
            return ValidationResult.Success;
        }
    }
}
