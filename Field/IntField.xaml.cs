using MrG.Base.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class IntField : ContentView, IBaseField
{
    public  ActionParameter Parameter { get; set; }
    public IntField(ActionParameter parameter)
    {
        InitializeComponent();
        Parameter = parameter;
        this.BindingContext = Parameter;
    }

    public object GetValue()
    {
        return Parameter.IntValue;
    }

}