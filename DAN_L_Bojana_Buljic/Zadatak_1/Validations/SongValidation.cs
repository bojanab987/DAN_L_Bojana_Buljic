using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class SongValidation:ValidationRule
    {
        /// <summary>
        /// Method for validating song duration
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>       
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string duration = value as string;
            if (TimeSpan.TryParseExact(duration, "hh\\:mm\\:ss", CultureInfo.CurrentCulture, out TimeSpan interval))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Invalid song duration format. Format as: hh:mm:ss");
            }
        }
    }
}
