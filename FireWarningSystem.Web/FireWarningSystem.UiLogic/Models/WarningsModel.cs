namespace FireWarningSystem.UiLogic.Models
{
    public class WarningsModel
    {
        public IEnumerable<WarningModel> _actWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _actWarningsError { get; set; }
        public IEnumerable<WarningModel> _invalidWarnings { get; set; } = Array.Empty<WarningModel>();
        public DateTime _lastUpdateTime  {get; set; }
        public IEnumerable<WarningModel> _ntWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _ntIncidentsError { get; set; }
        public IEnumerable<WarningModel> _nswWarings { get; set; } = Array.Empty<WarningModel>();
        public bool _nswWarningsError { get; set; }
        public IEnumerable<WarningModel> _qldWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _qldWarningsError { get; set; }
        public IEnumerable<WarningModel> _saWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _saWarningsError { get; set; }
        public IEnumerable<WarningModel> _tasWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _tasWarningsError { get; set; }
        public IEnumerable<WarningModel> _vicWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _vicWarningsError { get; set; }
        public IEnumerable<WarningModel> _waWarnings { get; set; } = Array.Empty<WarningModel>();
        public bool _waWarningsError { get; set; }
    }
}
