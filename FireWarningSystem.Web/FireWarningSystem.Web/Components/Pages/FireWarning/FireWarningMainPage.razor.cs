using FireWarningSystem.UiLogic.Models.FireWarningModels;
using FireWarningSystem.UiLogic.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages.FireWarning
{
    public partial class FireWarningMainPage
    {
        [Inject]
        private IFireWarningViewModel ViewModel { get; set; } = default!;


        public FireWarningMainModel Model
        {
            get { return ViewModel.Model; }
            set { ViewModel.Model = value; }
        }


        protected override async Task OnInitializedAsync()
        {
            await ViewModel.OnInitialisedAsync();
            StateHasChanged();
            await ViewModel.RenderMapAsync();
        }
    }
}
