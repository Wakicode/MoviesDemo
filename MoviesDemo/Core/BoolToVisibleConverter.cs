using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace MoviesDemo.Core
{
    public class BoolToVisibleConverter : IValueConverter
    {
        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        public BoolToVisibleConverter() { }

        #endregion

        #region Propiedades

        public bool Collapse { get; set; }
        public bool Reverse { get; set; }

        #endregion

        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;

            if (bValue != Reverse)
            {
                return Visibility.Visible;
            }
            else
            {
                if (Collapse)
                    return Visibility.Collapsed;
                else
                    return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return !Reverse;
            else
                return Reverse;
        }

        #endregion

    }
}
