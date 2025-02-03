using FireWarningSystem.UiLogic.Models.FireWarningModels;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages.FireWarning.Components
{
    public partial class ApiStatusResultItemComponent
    {
        [Parameter]
        public IEnumerable<WarningModel> Warnings { get; set; } = Array.Empty<WarningModel>();

        [Parameter]
        public string State { get; set; } = string.Empty;

        [Parameter]
        public bool Error { get; set; }
    }
}
