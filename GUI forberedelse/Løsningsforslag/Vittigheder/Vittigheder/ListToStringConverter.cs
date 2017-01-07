using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Vittigheder.Models;

namespace Vittigheder
{
    public class StringToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ""; //Der skal ikke overføres noget denne vej
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as string;
            if (list != null)
            {
                char[] delimiters = { ',' };
                var categories = list.Split(delimiters);
                var tags = new List<Tag>();

                foreach (var item in categories)
                {
                    var tag = new Tag { TagString = item };
                    tags.Add(tag);
                }
                return tags;
            }
            return null;
        }
    }
}
