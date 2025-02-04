using System.Collections;
using System.Net.Http;
using System.Net.Http.Json;
using WarningClient.Models;

namespace WarningClient.Client.Implementation
{
    public class WarningsClient : IWarningClient
    {
        private readonly HttpClient _actHttpClient;
        private readonly HttpClient _cfaHttpClient;
        private readonly HttpClient _nswHttpClient;
        private readonly HttpClient _ntHttpClient;
        private readonly HttpClient _qldHttpClient;
        private readonly HttpClient _saHttpClient;
        private readonly HttpClient _tasHttpClient;
        private readonly HttpClient _waHttpClient;


        public const string ACT_HTTPCLIENT_API_PUBLIC = "ActWarningClient";
        public const string CFA_HTTPCLIENT_API_PUBLIC = "CfaWarningClient";
        public const string NSW_HTTPCLIENT_API_PUBLIC = "NswWarningClient";
        public const string NT_HTTPCLIENT_API_PUBLIC = "NtWarningsUrl";
        public const string QLD_HTTPCLIENT_API_PUBLIC = "QldWarningClient";
        public const string SA_HTTPCLIENT_API_PUBLIC = "SaWarningClient";
        public const string TAS_HTTPCLIENT_API_PUBLIC = "TasWarningClient";
        public const string WA_HTTPCLIENT_API_PUBLIC = "WaWarningClient";



        public WarningsClient(IHttpClientFactory clientFactory)
        {
            _actHttpClient = clientFactory.CreateClient(ACT_HTTPCLIENT_API_PUBLIC);
            _cfaHttpClient = clientFactory.CreateClient(CFA_HTTPCLIENT_API_PUBLIC);
            _nswHttpClient = clientFactory.CreateClient(NSW_HTTPCLIENT_API_PUBLIC);
            _ntHttpClient = clientFactory.CreateClient(NT_HTTPCLIENT_API_PUBLIC);
            _qldHttpClient = clientFactory.CreateClient(QLD_HTTPCLIENT_API_PUBLIC);
            _saHttpClient = clientFactory.CreateClient(SA_HTTPCLIENT_API_PUBLIC);
            _tasHttpClient = clientFactory.CreateClient(TAS_HTTPCLIENT_API_PUBLIC);
            _waHttpClient = clientFactory.CreateClient(WA_HTTPCLIENT_API_PUBLIC);
        }

        public async Task<IEnumerable<ActIncident>> GetActWarningsAsync()
        {
            var incidents = await _actHttpClient.GetAsync("incidents/feed");

            incidents.EnsureSuccessStatusCode();

            return await incidents.Content.ReadFromJsonAsync<List<ActIncident>>() ?? new List<ActIncident>();
        }

        public async Task<IEnumerable<VicIncident>> GetVicWarningsAsync()
        {
            var result = await _cfaHttpClient.GetAsync("Show?pageId=getIncidentJSON");

            result.EnsureSuccessStatusCode();

            var items = await result.Content.ReadFromJsonAsync<CfaIncidents>() ?? new CfaIncidents();
            return items.Results;
        }

        public async Task<IEnumerable<NswFeature>> GetNswWarningsAsync()
        {
            var result = await _nswHttpClient.GetAsync("feeds/majorIncidents.json");

            result.EnsureSuccessStatusCode();

            var items = await result.Content.ReadFromJsonAsync<NswFeatureCollection>() ?? new NswFeatureCollection();

            return items.Features;
        }

        public async Task<IEnumerable<NtIncident>> GetNtWarningsAsync()
        {
            var result = await _ntHttpClient.GetAsync("incidentmap/json/incidents.json");

            result.EnsureSuccessStatusCode();

            var items = await result.Content.ReadFromJsonAsync<NtIncidentResponse>() ?? new NtIncidentResponse();
            return items.Incidents.Features;
        }

        public async Task<IEnumerable<QldIncident>> GetQldWarningsAsync()
        {
            var incidents = await _qldHttpClient.GetAsync("vkTwD8kHw2woKBqV/arcgis/rest/services/ESCAD_Current_Incidents_Public/FeatureServer/0/query?f=geojson&where=1%3D1&outFields=*");

            incidents.EnsureSuccessStatusCode();

            var result = await incidents.Content.ReadFromJsonAsync<QLdFeatureCollection>() ?? new QLdFeatureCollection();

            return result.Features;
        }

        public async Task<IEnumerable<SaIncident>> GetSaWarningsAsync()
        {
            var response = await _saHttpClient.GetAsync("prod/cfs/criimson/cfs_current_incidents.json");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<SaIncident>>() ?? new List<SaIncident>();
        }

        public async Task<IEnumerable<TasFeature>> GetTasWarningsAsync()
        {
            var response = await _tasHttpClient.GetAsync("data/data.geojson");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TasFeatureCollection>() ?? new TasFeatureCollection();

            return result.Features;
        }

        public async Task<IEnumerable<WaIncident>> GetWaWarningsAsync()
        {
            var response = await _waHttpClient.GetAsync("v1/incidents");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WaIncidents>() ?? new WaIncidents();

            return result.Incidents;
        }
    }
}
