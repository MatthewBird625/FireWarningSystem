using FireWarningSystem.UiLogic.Models;
using FireWarningSystem.UiLogic.Validators;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FireWarningSystem.Web.Components.Pages.Components
{
    public partial class ContactComponent
    {
        [Parameter]
        public ContactModel Model { get; set; } = new();

        private MudForm? Form { get; set; } = default!;

        [Parameter]
        public EventCallback Back {  get; set; }

        [Parameter]
        public EventCallback Submit { get; set; }

        private ContactValidator Validator { get; set; } = new();

        private async Task SubmitAsync() 
        {
            await Form!.Validate();

            if (Form.IsValid)
            {
                await Submit.InvokeAsync();
            }
        }
    }
}
