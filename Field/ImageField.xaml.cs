using MrG.AI.Client.Data.Action;
using MrG.Maui.Factories;

namespace MrG.Maui.Field;

public partial class ImageField : ContentView, IBaseField
{
    public ActionParameter Parameter { get; set; }
    public ImageField(ActionParameter parameter)
    {
        InitializeComponent();
        Parameter = parameter;
        this.BindingContext = Parameter;
    }

    private async void SelectImage(object sender, EventArgs e)
    {
        var result = await MediaPicker.PickPhotoAsync();
        if (result != null)
        {
            //read image as base64
            var stream = await result.OpenReadAsync();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            Parameter.ImageValue = Convert.ToBase64String(bytes);
            Parameter.Value = result.FullPath;
        }
    }

    public object GetValue()
    {
        return Parameter.ImageValue;
    }
}