using MrG.AI.Client.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class FloatField : ContentView, IBaseField
{
    public ActionParameter Parameter { get; set; }
    public FloatField(ActionParameter parameter)
    {
        InitializeComponent();
        Parameter = parameter;
        this.BindingContext = Parameter;
    }

    public object GetValue()
    {
        return Parameter.FloatValue;
    }
}