using MrG.AI.Client.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class BoolField : ContentView, IBaseField
{
    public  ActionParameter Parameter { get; set; }
	public BoolField(ActionParameter parameter)
	{
		InitializeComponent();
		Parameter = parameter;
		this.BindingContext = Parameter;
	}

    public object GetValue()
    {
		return Parameter.BoolValue;
    }
}