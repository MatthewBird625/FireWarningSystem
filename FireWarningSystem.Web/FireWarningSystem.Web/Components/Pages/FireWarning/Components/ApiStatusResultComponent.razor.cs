using FireWarningSystem.UiLogic.Models.FireWarningModels;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages.FireWarning.Components
{
    public partial class ApiStatusResultComponent
    {
        [Parameter]
        public WarningsModel Model { get; set; } = new();


        [Parameter]
        public EventCallback ContactForm { get; set; }

        [Parameter]
        public EventCallback RefreshStatus { get; set; }
    }
}
