using MrG.Base.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class SelectField : ContentView, IBaseField
{
    public ActionParameter Parameter { get; set; }
    public SelectField(ActionParameter parameter)
    {
        InitializeComponent();
        Parameter = parameter;
        this.BindingContext = Parameter;
    }

    public object GetValue()
    {
        if (Parameter.SelectValue== null || Parameter.SelectValue.Value==null)
        {
            return "";
        }
        return Parameter.SelectValue.Value;
    }
}