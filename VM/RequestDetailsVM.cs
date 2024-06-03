using MrG.AI.Client.Data.Action;
using MrG.AI.Client.Database.Data;
using MrG.AI.Client.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrG.Maui.VM
{
    [QueryProperty(nameof(Request), nameof(Request))]
    public class RequestDetailsVM : MrG.AI.Client.VM.RequestDetailsVM
    {
        Request? request;
        public Request? Request
        {
            get => request;
            set
            {
                SetProperty(ref request, value);
            }
        }

        
    }
}
