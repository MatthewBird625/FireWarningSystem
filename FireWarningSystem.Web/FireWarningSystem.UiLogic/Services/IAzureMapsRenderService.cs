using FireWarningSystem.UiLogic.Models.FireWarningModels;

namespace FireWarningSystem.UiLogic.Services
{
    public interface IAzureMapsRenderService
    {
        Task GenerateWarningsMap(WarningsModel incidents);
    }
}
