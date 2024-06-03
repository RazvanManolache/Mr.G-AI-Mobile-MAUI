using MrG.AI.Client;
using MrG.AI.Client.Data;
using MrG.AI.Client.Data.Action;
using MrG.AI.Client.Helpers;
using MrG.AI.Client.VM;

namespace MrG.Maui
{

    public partial class ActionList : ContentPage
	{
       
        public string? SearchText { get; set; }
        public ActionList()
		{
			
			InitializeComponent();
			SocketHelper.OnActionsUpdated += OnActionsUpdated;
            OnActionsUpdated(Server.Instance?.Actions?.ToList());
		}

		private void OnActionsUpdated(List<ActionApi> actions)
		{
			ObservableObject.SetProperty(this.BindingContext, "Actions", actions);
        }

		private void RefreshCommand(object sender, EventArgs e)
		{
			SocketHelper.GetActions();

        }

		private void ActionClicked(object sender, EventArgs e)
		{
			if (sender == null) return;
			if (!(sender is Button)) return;
			var button = (Button)sender;
			if (button.BindingContext == null) return;

			var action = (ActionApi)(button as Button).BindingContext;
			Shell.Current.GoToAsync("/action_details", new ShellNavigationQueryParameters()
					{
						{ nameof(ActionApi), action }
					});
		}
    }
}