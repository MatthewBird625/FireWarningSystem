using FireWarningSystem.UiLogic.Models;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages.Components
{
    public partial class ApiStatusResultComponent
    {
        [Parameter]
        public WarningsModel Model { get; set; } = new();
        
        [Parameter]
        public EventCallback RefreshStatus { get; set; }
    }
}
