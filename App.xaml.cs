using MrG.Base.Data;
using MrG.Base.Database;
using MrG.Base.Helpers;
using MrG.Maui.Helpers;

namespace MrG.Maui
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
           
            SetLoading();
            DatabaseHelper.DatabaseDirectory = FileSystem.AppDataDirectory;
            new DatabaseHelper();
            SocketHelper.OnLogoutEvent += (server) =>
            {
                Server.Instance = null;
                SetLogin();
            };
            new SecureStorageHelper().GetServer().ContinueWith(a=>
            {
               
                    if (a.Result != null)
                    {
                        Server.Instance = a.Result;
                        SetNavigation();
                    }
                    else
                    {
                        SetLogin();
                    }
               
            });
        }

        public void SetLoading()
        {
            SetMainPage(new Loading());
        }
        public void SetNavigation()
        {
            SetMainPage(new AppShell());
        }

        public void SetLogin()
        {
            var login = new Login();
            login.LoginSucceeded += LoginSucceeded;
            SetMainPage(login);
        }

        private async void LoginSucceeded(object? sender, Server server)
        {
            Server.Instance = server;
            await new SecureStorageHelper().WriteServer(server);
            SetNavigation();
        }

        public void SetMainPage(Page page)
        {
            if (!this.Dispatcher.IsDispatchRequired)
                MainPage = page;
            else
            {
                this.Dispatcher.Dispatch(() =>
                {
                    SetMainPage(page);
                });
                
            }
                
            
        }
    }
}
