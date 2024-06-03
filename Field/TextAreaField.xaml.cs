using MrG.Base.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class TextAreaField : ContentView, IBaseField
{
    public ActionParameter Parameter { get; set; }
    public TextAreaField(ActionParameter parameter)
    {
        InitializeComponent();
        Parameter = parameter;
        this.BindingContext = Parameter;
    }

    public object GetValue()
    {
        if (Parameter.Value == null)
            return "";
        return Parameter.Value;
    }
}