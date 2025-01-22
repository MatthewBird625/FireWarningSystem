using MudBlazor;

namespace FireWarningSystem.UiLogic.Services.Implementation
{
    public class SnackbarService : ISnackbarService
    {
        private readonly ISnackbar _snackbar;

        public SnackbarService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void Error(string message)
        {
            _snackbar.Add(message, Severity.Error);
        }

        public void Info(string message)
        {
            _snackbar.Add(message, Severity.Info);
        }

        public void Normal(string message)
        {
            _snackbar.Add(message, Severity.Normal);
        }

        public void Success(string message)
        {
            _snackbar.Add(message, Severity.Success);
        }

        public void Warning(string message)
        {
            _snackbar.Add(message, Severity.Warning);
        }
    }
}
