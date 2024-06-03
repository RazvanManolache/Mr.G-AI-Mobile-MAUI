
using MrG.Base.Database.Data;

namespace MrG.Maui.Helpers
{
    public class RequestDetailsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? TextTemplate { get; set; }
        public DataTemplate? ImageTemplate { get; set; }

        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            if (item == null)
            {
                return null;
            }
            if(item is OutputItem outputItem)
            {
                if (outputItem.Type == Base.Enum.ResultType.Images)
                {
                    return ImageTemplate;
                }
                else
                {
                    return TextTemplate;
                }

            }
           

            return null;
        }
    }
}
