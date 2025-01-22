using FireWarningSystem.UiLogic.Models;

namespace FireWarningSystem.UiLogic.Services
{
    public interface IAzureMapsRenderService
    {
        Task GenerateWarningsMap(WarningsModel incidents);
    }
}
