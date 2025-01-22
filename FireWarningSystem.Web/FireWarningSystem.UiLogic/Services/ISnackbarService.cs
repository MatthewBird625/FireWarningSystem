namespace FireWarningSystem.UiLogic.Services
{
    public interface ISnackbarService
    {
        public void Error(string message);
        public void Info(string message);
        public void Normal(string message);
        public void Success(string message);
        public void Warning(string message);
    }
}
