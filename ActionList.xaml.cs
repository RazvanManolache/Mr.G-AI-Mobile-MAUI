using MrG.Base;
using MrG.Base.Data;
using MrG.Base.Data.Action;
using MrG.Base.Helpers;
using MrG.Base.VM;

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