using System;
using System.Text.RegularExpressions;


namespace MrG.Maui.Behaviors
{
    public class IpAddressValidatorBehavior : Behavior<Entry>
    {
        Color? BackgroundColor { get; set; }
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (sender!=null)
            {
                var entry = (Entry)sender;
                var isValid = IsValidIpAddress(entry.Text);
                if(BackgroundColor == null)
                {
                    BackgroundColor = entry.BackgroundColor;
                }
                entry.BackgroundColor = isValid ? BackgroundColor : Color.FromRgba("AF0000");
            }
           
        }

        private bool IsValidIpAddress(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                return false;

            // Regular expression pattern for IP address validation
            string pattern = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

            return Regex.IsMatch(ipAddress, pattern);
        }
    }
}
