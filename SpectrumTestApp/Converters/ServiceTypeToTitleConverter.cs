using SpectrumTestApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SpectrumTestApp.Converters
{
    /// <summary>
    /// ServiceTypeToTitleConverter
    /// </summary>
    /// <seealso cref="Xamarin.Forms.IValueConverter" />
    public class ServiceTypeToTitleConverter : IValueConverter
    {
        /// <summary>
        /// Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ServiceTypeEnum type)
            {
                switch (type)
                {
                    case ServiceTypeEnum.Internet:
                        return "INTERNET";
                    case ServiceTypeEnum.DoublePack:
                        return "INTERNET + TV";
                    case ServiceTypeEnum.TriplePack:
                        return "INTERNET + TV + VOICE";
                    default:
                        return value;
                }
            }
            return value;
        }

        /// <summary>
        /// Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return value;
        }
    }
}
