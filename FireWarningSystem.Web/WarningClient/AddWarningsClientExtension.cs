using WarningClient.Client;
using WarningClient.Client.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WarningClient
{
    public static class AddWarningsClientExtension
    {
        public static void AddWarningClient(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddTransient<IWarningClient, WarningsClient>();

            collection.AddHttpClient(WarningsClient.CFA_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["VicWarningUrl"] 
                    ?? throw new InvalidCastException("CFA Url is not set."));
            });

            collection.AddHttpClient(WarningsClient.ACT_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["ActWarningUrl"]
                    ?? throw new InvalidCastException("Act Url is not set."));
            });

            collection.AddHttpClient(WarningsClient.NSW_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["NswWarningUrl"]
                    ?? throw new InvalidCastException("Nsw Url is not set."));
            });


            collection.AddHttpClient(WarningsClient.NT_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["NtWarningUrl"]
                    ?? throw new InvalidCastException("Nsw Url is not set."));
            });

            collection.AddHttpClient(WarningsClient.QLD_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["QldWarningUrl"]
                    ?? throw new InvalidCastException("Qld Url is not set."));
            });

            collection.AddHttpClient(WarningsClient.SA_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["SaWarningUrl"]
                    ?? throw new InvalidCastException("SA Url is not set."));
            });


            collection.AddHttpClient(WarningsClient.TAS_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["TasWarningUrl"]
                    ?? throw new InvalidCastException("SA Url is not set."));
            });

            collection.AddHttpClient(WarningsClient.WA_HTTPCLIENT_API_PUBLIC, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["WaWarningUrl"]
                    ?? throw new InvalidCastException("WA Url is not set."));
            });
        }
    }
}
