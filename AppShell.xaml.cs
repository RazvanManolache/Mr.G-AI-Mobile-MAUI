namespace MrG.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("actions", typeof(ActionList));
            Routing.RegisterRoute("requests", typeof(RequestList));
            Routing.RegisterRoute("actions/action_details", typeof(ActionDetails));
            Routing.RegisterRoute("requests/request_details", typeof(RequestDetails));
        }
    }
}
