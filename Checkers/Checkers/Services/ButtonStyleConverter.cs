using Checkers.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Checkers.Services
{
    public class ButtonStyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3)
                return DependencyProperty.UnsetValue;

            bool color = (bool)values[0];
            bool isRecommended = (bool)values[1];
            bool isSelected = (bool)values[2];

            if (color)
            {
                if (isRecommended)
                {
                    return Application.Current.FindResource("RecomendedCellStyle");
                }
                else if (isSelected)
                {
                    return Application.Current.FindResource("SelectedCellStyle");
                }
                else
                    return Application.Current.FindResource("RedCellStyle");
            }
            else
            {
                return Application.Current.FindResource("WhiteCellStyle");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}