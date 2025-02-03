using FireWarningSystem.UiLogic.Models;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages.Components
{
    public partial class ContactComponent
    {
        [Parameter]
        public ContactModel Model { get; set; } = new();

        [Parameter]
        public EventCallback Back {  get; set; }

        [Parameter]
        public EventCallback Submit { get; set; }
    }
}
