using MrG.AI.Client.Data.Action;
using MrG.Maui.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrG.Maui.Factories
{
    public static class FieldFactory
    {
        public static IView CreateField(ActionParameter parameter)
        {
            switch(parameter.Type)
            {
                case "STRING":
                    return new TextAreaField(parameter);
                case "INT":
                    return new IntField(parameter);
                case "FLOAT":
                    return new FloatField(parameter);
                case "BOOLEAN":
                    return new BoolField(parameter);
                case "SELECT":
                    return new SelectField(parameter);
                case "IMAGE":
                    return new ImageField(parameter);
                default:
                    return new TextField(parameter);
            }
            
        }

    }
}
