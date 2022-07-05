using System;
using Xamarin.Forms;

namespace TaskProject.Common.Converters
{
    public class NotNullConverter : IValueConverter
    {
        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if object is not null</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter is string stringParam)
            {
                if (bool.TryParse(stringParam, out bool shouldInvertResult))
                {
                    if (shouldInvertResult)
                    {
                        return value == null;
                    }
                }
            }

            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
