using FireWarningSystem.UiLogic.Models.FireWarningModels;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace FireWarningSystem.UiLogic.Services.Implementation
{
    public class AzureMapsRenderService : IAzureMapsRenderService
    {
        private readonly IConfiguration _configuration;
        private readonly IJSRuntime _runtime;

        private string _subKey { get; set; }

        public AzureMapsRenderService(IConfiguration configuration, IJSRuntime runtime)
        {
            _configuration = configuration;
            _runtime = runtime;
            _subKey = configuration["AzureMapsSubscriptionKey"] ?? throw new InvalidOperationException("Azure maps key is missing.");
        }

        public async Task GenerateWarningsMap(WarningsModel incidents)
        {
            await _runtime.InvokeVoidAsync("GenerateStatusMap", _subKey, incidents.ActWarnings, incidents.VicWarnings, incidents.NswWarnings, incidents.NtWarnings, incidents.QldWarnings, incidents.SaWarnings, incidents.TasWarnings, incidents.WaWarnings);
        }
    }
}
