using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Versta.Web.Arrtibutes
{
    public class StreetAttribute : ValidationAttribute
    {
        public StreetAttribute()
        { }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            var streetName = value as string;

            return !streetName.Any(x => x == ',');
        }
    }
}
