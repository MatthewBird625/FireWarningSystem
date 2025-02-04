using FireWarningSystem.UiLogic.Models.FireWarningModels;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages.FireWarning.Components
{
    public partial class FailedRendersComponent
    {
        [Parameter]
        public IEnumerable<WarningModel> Warnings { get; set; } = Array.Empty<WarningModel>();
    }
}
