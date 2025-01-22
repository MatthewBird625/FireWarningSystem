namespace FireWarningSystem.UiLogic.Models
{
    public class WarningModel
    {
        public string Description { get; set; } = string.Empty;
        public string StateType { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
