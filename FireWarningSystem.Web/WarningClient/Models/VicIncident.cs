namespace WarningClient.Models
{
    public class CfaIncidents()
    {
        public IEnumerable<VicIncident> Results { get; set; } = Array.Empty<VicIncident>();
    }

    public class VicIncident
    {
        public int IncidentNo { get; set; }
        public string OriginDateTime { get; set; } = string.Empty;
        public string IncidentType { get; set; } = string.Empty;
        public string IncidentStatus { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ResourceCount { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Category1 { get; set; } = string.Empty;
        public string Category2 { get; set; } = string.Empty;

        //UNUSED API PROPERTIES - commented out for more reliability.

        //public string LastUpdateDateTime { get; set; } = string.Empty;
        //public string IncidentLocation { get; set; } = string.Empty;
        //public string IncidentSize { get; set; } = string.Empty;
        //public string Territory { get; set; } = string.Empty;
        //public string EventCode { get; set; } = string.Empty;
        //public string FireDistrict { get; set; } = string.Empty;
        //public string Municipality { get; set; } = string.Empty;
        //public string FeedType { get; set; } = string.Empty;
        //public string Agency { get; set; } = string.Empty;
        //public string OriginStatus { get; set; } = string.Empty;
        //public string CreatedDt { get; set; } = string.Empty;
        //public string Type { get; set; } = string.Empty;
    }
}
