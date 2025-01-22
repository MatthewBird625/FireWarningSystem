using FireWarningSystem.UiLogic.Models;

namespace FireWarningSystem.UiLogic.ViewModels
{
    public interface IFireWarningViewModel
    {
        public FireWarningMainModel Model { get; set; }

        Task OnInitialisedAsync();
        Task RenderMapAsync();
        Task RefreshWarningsAsync();

    }
}
