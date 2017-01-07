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
    public class ListOfJokesToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as List<Joke>;
            string jokes = "";

            foreach (var item in list)
            {
                jokes =  jokes + "Date: " + item.Date + "\n" +
                        "Tekst: " + item.JokeString + "\n" +
                        "Kilde: " + item.Source + "\n" +
                        "Emneord: ";

                foreach (var tag in item.Tags)
                {
                    jokes = jokes + tag.TagString + " ";
                }

                jokes = jokes + "\n\n";
            }
            return jokes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
