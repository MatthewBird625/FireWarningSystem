using FireWarningSystem.UiLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarningSystem.UiLogic.ViewModels
{
    public interface IFireWarningViewModel
    {
        public FireWarningMainModel Model { get; set; }

        public Task OnInitialisedAsync();
        public Task RefreshWarningsAsync();
    }
}
