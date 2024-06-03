using MrG.AI.Client.Data.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrG.Maui.Factories
{
    public interface IBaseField
    {
        ActionParameter Parameter { get; set; }
        public object GetValue();
    }
}
