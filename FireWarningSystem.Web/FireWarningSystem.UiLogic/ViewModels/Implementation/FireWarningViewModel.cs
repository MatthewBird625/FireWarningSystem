using FireWarningSystem.UiLogic.Models;
using FireWarningSystem.UiLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor;
using WarningClient.Client;

namespace FireWarningSystem.UiLogic.ViewModels.Implementation
{
    public class FireWarningViewModel : IFireWarningViewModel
    {
        IConfiguration _configuration;
        ILogger<FireWarningViewModel> _logger;
        ISnackbarService _snackbarService;
        IWarningClient _warningClient;

        public FireWarningViewModel(IConfiguration configuration, ILogger<FireWarningViewModel> logger, ISnackbarService snackbarService, IWarningClient warningClient)
        {
            _configuration = configuration;
            _logger = logger;
            _snackbarService = snackbarService;
            _warningClient = warningClient;
        }

        public FireWarningMainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        private FireWarningMainModel _model = new();

        public async Task OnInitialisedAsync()
        {
            try
            {
                Model.Loading = true;
                await GenerateWarningsAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unable to load the Fire Activity Page.");
                _snackbarService.Error($"Something went wrong, Please contact {_configuration["supportEmail"]}");
            }
            finally 
            {
                Model.Loading = false;
            }
        }

        public async Task RefreshWarningsAsync() 
        {
            await GenerateWarningsAsync();
        }

        private async Task GenerateWarningsAsync()
        {
            //reset warnings
            Model.Warnings = new();

            //collect all warnings in parallel and then try catch individually to containerise errors to each API result. 
            var actWarnings = _warningClient.GetActWarningsAsync();
            var vicWarnings = _warningClient.GetCfaWarningsAsync();
            var ntWarnings = _warningClient.GetNtWarningsAsync();
            var nswWarnings = _warningClient.GetNswWarningsAsync();
            var qldWarnings = _warningClient.GetQldWarningsAsync();
            var saWarnings = _warningClient.GetSaWarningsAsync();
            var tasWarnings = _warningClient.GetTasWarningsAsync();
            var waWarnings = _warningClient.GetWaWarningsAsync();

            try
            {
                await Task.WhenAll(actWarnings);
                Model.Warnings.ActWarnings = WarningModelMap.Map(actWarnings.Result.Where(x => x.Region == "act"));
            }
            catch (Exception e)
            {
                Model.Warnings.ActWarningsError = true;
                _snackbarService.Error("Unable to get ACT Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get ACT Warnings.");
            }
            try
            {
                await Task.WhenAll(nswWarnings);
                Model.Warnings.NswWarnings = WarningModelMap.Map(nswWarnings.Result);
            }
            catch (Exception e)
            {
                Model.Warnings.NswWarningsError = true;
                _snackbarService.Error("Unable to get NSW Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get NSW Warnings.");
            }
            try
            {
                await Task.WhenAll(ntWarnings);
                Model.Warnings.NtWarnings = WarningModelMap.Map(ntWarnings.Result);
            }
            catch (Exception e)
            {
                Model.Warnings.NtWarningsError = true;
                _snackbarService.Error("Unable to get NT Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get NT Warnings.");
            }
            try
            {
                await Task.WhenAll(qldWarnings);
                Model.Warnings.QldWarnings = WarningModelMap.Map(qldWarnings.Result);
            }
            catch (Exception e)
            {

                Model.Warnings.QldWarningsError = true;
                _snackbarService.Error("Unable to get QLD Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get QLD Warnings.");
            }
            try
            {
                await Task.WhenAll(saWarnings);
                Model.Warnings.SaWarnings = WarningModelMap.Map(saWarnings.Result);
            }
            catch (Exception e)
            {

                Model.Warnings.SaWarningsError = true;
                _snackbarService.Error("Unable to get SA Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get SA Warnings.");
            }
            try
            {
                await Task.WhenAll(tasWarnings);
                Model.Warnings.TasWarnings = WarningModelMap.Map(tasWarnings.Result);
            }
            catch (Exception e)
            {

                Model.Warnings.TasWarningsError = true;
                _snackbarService.Error("Unable to get Tas Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get Tas Warnings.");
            }
            try
            {
                await Task.WhenAll(vicWarnings);
                Model.Warnings.VicWarnings = WarningModelMap.Map(vicWarnings.Result);
            }
            catch (Exception e)
            {

                Model.Warnings.VicWarningsError = true;
                _snackbarService.Error("Unable to get VIC Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get VIC Warnings.");
            }
            try
            {
                await Task.WhenAll(waWarnings);
                Model.Warnings.WaWarnings = WarningModelMap.Map(waWarnings.Result);
            }
            catch (Exception e)
            {

                Model.Warnings.WaWarningsError = true;
                _snackbarService.Error("Unable to get WA Warnings from State emergency service. Please contact support if this persists.");
                _logger.LogError(e, "Unable to get WA Warnings.");
            }

            //Get Warnings That have invalid location for placement in a table.

            Model.Warnings.InvalidWarnings =
                Model.Warnings.ActWarnings.WhereInvalidCoordinates()
                .Concat(Model.Warnings.VicWarnings.WhereInvalidCoordinates())
                .Concat(Model.Warnings.NswWarnings.WhereInvalidCoordinates())
                .Concat(Model.Warnings.QldWarnings.WhereInvalidCoordinates())
                .Concat(Model.Warnings.NtWarnings.WhereInvalidCoordinates())
                .Concat(Model.Warnings.WaWarnings.WhereInvalidCoordinates())
                .Concat(Model.Warnings.SaWarnings.WhereInvalidCoordinates())
                .Concat(Model.Warnings.TasWarnings.WhereInvalidCoordinates());
        }
    }
}
