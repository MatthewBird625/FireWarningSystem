using WarningClient.Models;

namespace WarningClient.Client
{
    public interface IWarningClient
    {
        Task<IEnumerable<ActIncident>> GetActWarningsAsync();
        Task<IEnumerable<VicIncident>> GetVicWarningsAsync();
        Task<IEnumerable<NswFeature>> GetNswWarningsAsync();
        Task<IEnumerable<NtIncident>> GetNtWarningsAsync();
        Task<IEnumerable<QldIncident>> GetQldWarningsAsync();
        Task<IEnumerable<SaIncident>> GetSaWarningsAsync();
        Task<IEnumerable<TasFeature>> GetTasWarningsAsync();
        Task<IEnumerable<WaIncident>> GetWaWarningsAsync();
    }
}
