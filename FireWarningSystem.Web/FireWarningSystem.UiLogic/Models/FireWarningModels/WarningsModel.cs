namespace FireWarningSystem.UiLogic.Models.FireWarningModels
{
    public class WarningsModel
    {
        public IEnumerable<WarningModel> ActWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool ActWarningsError { get; set; }
        public IEnumerable<WarningModel> InvalidWarnings { get; set; } = Array.Empty<WarningModel>();
        public DateTime LastUpdateTime { get; set; }
        public IEnumerable<WarningModel> NtWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool NtWarningsError { get; set; }
        public IEnumerable<WarningModel> NswWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool NswWarningsError { get; set; }
        public IEnumerable<WarningModel> QldWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool QldWarningsError { get; set; }
        public IEnumerable<WarningModel> SaWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool SaWarningsError { get; set; }
        public IEnumerable<WarningModel> TasWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool TasWarningsError { get; set; }
        public IEnumerable<WarningModel> VicWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool VicWarningsError { get; set; }
        public IEnumerable<WarningModel> WaWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool WaWarningsError { get; set; }
    }
}
