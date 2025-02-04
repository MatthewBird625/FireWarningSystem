namespace FireWarningSystem.UiLogic.Models.FireWarningModels
{
    public class FireWarningMainModel
    {
        public ContactModel Contact { get; set; } = new();
        public bool Loading { get; set; }
        public FireWarningViewType ViewType { get; set; }
        public WarningsModel Warnings { get; set; } = new();
    }
}
