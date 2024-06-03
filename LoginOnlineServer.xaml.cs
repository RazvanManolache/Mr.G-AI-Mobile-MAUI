using MrG.Maui.Helpers;

namespace MrG.Maui
{
    public partial class LoginOnlineServer : ContentView
    {
        public LoginOnlineServer()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {

        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await HttpHelper.OpenRegisterUrl();
        }

    }
}