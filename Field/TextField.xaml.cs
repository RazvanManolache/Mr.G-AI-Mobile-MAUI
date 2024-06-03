using MrG.Base.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class TextField : ContentView, IBaseField
{
    public ActionParameter Parameter { get; set; }
    public TextField(ActionParameter parameter)
    {
        InitializeComponent();
        Parameter = parameter;
        this.BindingContext = Parameter;
    }

    public object GetValue()
    {
        if(Parameter.Value == null)
            return "";
        return Parameter.Value;
    }
}