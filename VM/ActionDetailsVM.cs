using MrG.AI.Client.Data.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrG.Maui.VM
{

    [QueryProperty(nameof(ActionApi), nameof(ActionApi))]
    public class ActionDetailsVM : MrG.AI.Client.VM.ActionDetailsVM
    {
        ActionApi? action;
        public ActionApi? ActionApi
        {
            get => action;
            set
            {
                SetProperty(ref action, value);
            }
        }
    }
}
