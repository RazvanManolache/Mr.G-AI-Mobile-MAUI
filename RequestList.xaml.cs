using MrG.AI.Client.Database;
using MrG.AI.Client.Database.Data;
using MrG.AI.Client.VM;
using MrG.Maui.Helpers;
using System.ComponentModel;

namespace MrG.Maui
{
    public partial class RequestList : ContentPage
	{
        RequestListVM Context => (RequestListVM)this.BindingContext;

        public RequestList()
		{
			InitializeComponent();
            Context.PropertyChanged += Context_PropertyChanged;
            LoadMoreClicked(null, null);
        }

        private void Context_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName==nameof(Context.SortOrder))
            {
                Context.Requests.Clear();
                LoadMoreClicked(null, null);
            }
        }

        private async void LoadMoreClicked(object sender, EventArgs e)
        {
            var cnt = Context.Requests.Count;
            var result = await DatabaseHelper.Instance.GetAll<Request>(cnt, cnt + 10, Context.SortOrder == "Desc");
            foreach (var item in result.Item1)
                Context.Requests.Add(item);
            if(result.Item2>Context.Requests.Count)
                Context.LoadMoreVisible = true;
            else
                Context.LoadMoreVisible = false;
           
        }

        private void OnPressedItem(object sender, EventArgs e)
        {
            var obj = (RequestDetailsList)sender;


            var item = (Request)obj.BindingContext;

            Shell.Current.GoToAsync("/request_details", new ShellNavigationQueryParameters()
            {
                { nameof(Request), item }
            });

        }
    }
}