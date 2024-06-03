using MrG.Base.Data.Action;
using MrG.Base.Database.Data;
using MrG.Base.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrG.Maui.VM
{
    [QueryProperty(nameof(Request), nameof(Request))]
    public class RequestDetailsVM : MrG.Base.VM.RequestDetailsVM
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
