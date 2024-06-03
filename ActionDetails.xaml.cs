using MrG.Base.Data;
using MrG.Base.Helpers;
using MrG.Maui.Factories;
using MrG.Maui.VM;

namespace MrG.Maui
{
    
    public partial class ActionDetails : ContentPage
    {
        ActionDetailsVM ViewModel => (ActionDetailsVM)this.BindingContext;
        public ActionDetails()
        {
            InitializeComponent();
            ViewModel.PropertyChanged += ActionDetails_PropertyChanged; ;
        }

        private void ActionDetails_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            for(int i = 0; i < ViewModel.ActionApi?.Parameters?.Count; i++)
            {
                var parameter = ViewModel.ActionApi.Parameters[i];
                
                var field = FieldFactory.CreateField(parameter);
                Fields.Children.Add(field);
            }
        }

        private void RunAction(object sender, EventArgs e)
        {
            if(ViewModel.ActionApi == null || ViewModel.ActionApi.Uuid==null) return;
            var values = new Dictionary<string, object>();
            foreach (var field in Fields.Children)
            {
                if (field is IBaseField fieldView)
                {
                    if(fieldView.Parameter != null && fieldView.Parameter.Name!=null)
                        values.Add(fieldView.Parameter.Name, fieldView.GetValue());
                }
            }
            SocketHelper.ExecuteApi(ViewModel.ActionApi, values);
            Shell.Current.GoToAsync("..");
        }
    }
}