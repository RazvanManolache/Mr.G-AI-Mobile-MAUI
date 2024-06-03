using MrG.AI.Client.Data;
using MrG.AI.Client.EventArgs;
using MrG.Maui.Helpers;

namespace MrG.Maui
{

    public partial class LoginLocalServer : ContentView
    {
        public LoginLocalServer()
        {
            InitializeComponent();
        }

        public event EventHandler<LocalServerEventArgs>? LoginSucceeded;




        Color? IpAddressBackgroundColor { get; set; }

        private void OnConnectClicked(object sender, EventArgs e)
        {
            LoginSucceeded?.Invoke(this, new LocalServerEventArgs() { ServerAddress = IPAddressField.Text, ServerName = ServerName });



        }

        private async void OnHowToClicked(object sender, EventArgs e)
        {
            await HttpHelper.OpenHowToUrl();
        }

        private void OnIPAddressChanged(object sender, TextChangedEventArgs e)
        {
            TestButton.IsEnabled = false;
            ConnectButton.IsEnabled = false;
            LocalServerNotificationLabel.Text = string.Empty;
            ValidateInputs();
        }
        private void ValidateInputs()
        {
            var isValid = false;
            if (IpAddressBackgroundColor == null)
            {
                IpAddressBackgroundColor = IPAddressField.BackgroundColor;
            }
            var value = IPAddressField.Text;
            isValid = Server.IsValidIpAddress(value);

            IPAddressField.BackgroundColor = isValid ? IpAddressBackgroundColor : Color.FromRgba("AF0000");


            TestButton.IsEnabled = isValid;
        }

        string ServerName = string.Empty;

        private async void OnTestClicked(object sender, EventArgs e)
        {
            LocalServerNotificationLabel.Text = string.Empty;
            ConnectButton.IsEnabled = false;
            var isValid = false;
            var value = IPAddressField.Text;
            var testUrl = Server.GetTestUrl(value);
            if (string.IsNullOrEmpty(testUrl))
            {
                LocalServerNotificationLabel.Text = "Invalid configuration. Application fault.";
                LocalServerNotificationLabel.TextColor = Color.FromRgba("FF0000");
                return;
            }

            var response = await Server.MakeHttpRequest(testUrl);
            if (!string.IsNullOrEmpty(response))
            {
                isValid = true;
                ServerName = response;
            }
            if (isValid)
            {
                LocalServerNotificationLabel.Text = "Connection successful to server - " + response;
                LocalServerNotificationLabel.TextColor = Color.FromRgba("00FF00");
            }
            else
            {
                LocalServerNotificationLabel.Text = "Connection failed";
                LocalServerNotificationLabel.TextColor = Color.FromRgba("FF0000");
            }
            ConnectButton.IsEnabled = isValid;
        }


    }
}