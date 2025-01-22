namespace FireWarningSystem.UiLogic.Models
{
    public class FireWarningMainModel
    {
        public bool Loading { get; set; }
        public WarningsModel Warnings { get; set; } = new();
    }
}
