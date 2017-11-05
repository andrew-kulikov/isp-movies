using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Movies.UI.View
{
	public class NameMultiValueConverter : DependencyObject, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return String.Format("{0}({1})", values[0], values[1]);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			string val = value as string;
			string[] s = val.Split('(');
			return new object[2] { s[0], s[1].Substring(0, s[1].Length - 1) };
		}
		
	}
}
