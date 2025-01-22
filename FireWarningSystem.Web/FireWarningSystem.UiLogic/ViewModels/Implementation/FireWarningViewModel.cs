using FireWarningSystem.UiLogic.Models;

namespace FireWarningSystem.UiLogic.ViewModels.Implementation
{
    public class FireWarningViewModel : IFireWarningViewModel
    {

        public FireWarningMainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        private FireWarningMainModel _model = new();
    }
}
