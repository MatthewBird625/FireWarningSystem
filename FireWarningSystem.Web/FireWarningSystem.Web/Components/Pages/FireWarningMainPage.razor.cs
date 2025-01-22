using FireWarningSystem.UiLogic.Models;
using FireWarningSystem.UiLogic.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FireWarningSystem.Web.Components.Pages
{
    public partial class FireWarningMainPage
    {
        [Inject]
        private IFireWarningViewModel ViewModel { get; set; } = default!;


        public FireWarningMainModel Model
        {
            get { return ViewModel.Model; }
            set { ViewModel.Model = value; }
        }
    }
}
