using FireWarningSystem.UiLogic.Models;
using WarningClient.Client;

namespace FireWarningSystem.UiLogic.ViewModels.Implementation
{
    public class FireWarningViewModel : IFireWarningViewModel
    {

        IWarningClient _warningClient;


        public FireWarningViewModel(IWarningClient warningClient)
        {
            _warningClient = warningClient;
        }

        public FireWarningMainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        private FireWarningMainModel _model = new();
    }
}
