using FireWarningSystem.UiLogic.Models.FireWarningModels;

namespace FireWarningSystem.UiLogic.ViewModels
{
    public interface IFireWarningViewModel
    {
        public FireWarningMainModel Model { get; set; }

        Task ChangeViewMode();
        Task OnInitialisedAsync();
        Task RenderMapAsync();
        Task RefreshWarningsAsync();
    }
}
