using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Safe.PL.ViewModel.Convertors
{
    public class ElapsedTimeToStringConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String resultStr = String.Empty;

            DateTime activityTime = (DateTime)value;
            DateTime currentTime = DateTime.Now;

            TimeSpan timeElapsed = currentTime - activityTime;

            if (timeElapsed.TotalDays >= 1)
            {
                resultStr = String.Format("{0:0} day(s) ago", timeElapsed.TotalDays);
            }
            else if (timeElapsed.TotalHours >= 1)
            {
                resultStr = String.Format("{0:0} hour(s) ago", timeElapsed.TotalHours);
            }
            else if (timeElapsed.TotalMinutes >= 1)
            {
                resultStr = String.Format("{0:0} minute(s) ago", timeElapsed.TotalMinutes);
            }
            else if (timeElapsed.TotalSeconds >= 1)
            {
                resultStr = String.Format("{0:0} second(s) ago", timeElapsed.TotalSeconds);
            }
            else
            {
                resultStr = "just now";
            }

            return resultStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Now;
        }
    }
}
