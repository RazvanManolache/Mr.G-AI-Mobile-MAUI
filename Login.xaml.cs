using MrG.Base.Data;
using MrG.Base.EventArgs;
using MrG.Maui.Helpers;
using System.Text.RegularExpressions;

namespace MrG.Maui
{

    public partial class Login : ContentPage
    {
        // make event fot finished login
        public event EventHandler<Server>? LoginSucceeded;

        public Login()
        {
            InitializeComponent();
        }
        // make events

        private void OnLocalServerOptionClicked(object sender, EventArgs e)
        {

        }

        private void OnOnlineServerOptionClicked(object sender, EventArgs e)
        {

        }

        private void LocalServerLoginSucceeded(object sender, LocalServerEventArgs e)
        {
            var server = new Server(e);
            LoginSucceeded?.Invoke(this, server);
        }
    }
}