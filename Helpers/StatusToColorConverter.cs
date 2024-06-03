using MrG.Base.Enum;
using System;
using System.Globalization;

namespace MrG.Maui.Helpers
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value==null)
            {
                return new Color(255, 255, 255);
            }
            if(value is string)
            {
                value = System.Enum.Parse(typeof(RequestStatus), value.ToString(),true);
            }
            // Check if the value is of the expected type
            if (value is RequestStatus status)
            {
                // Perform the conversion based on the status value
                switch (status)
                {
                    case RequestStatus.Requested:
                        return new Color(255, 255, 0);
                    case RequestStatus.Queued:
                        return new Color(0, 255, 255);
                    case RequestStatus.Processing:
                        return new Color(255, 0, 0);
                    case RequestStatus.Finished:
                        return new Color(0, 255, 0);
                    case RequestStatus.Failed:
                        return new Color(255, 0, 0);
                    default:
                        return new Color(255, 255, 255);
                }
            }

            // Return a default color if the value is not a string or doesn't match any expected status
            return new Color(255, 255, 255);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
