namespace WarningClient.Models
{

    public class ActIncident
    {
        public string Agency { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        //unused API properties

        //public string AlertLevel { get; set; } = string.Empty;
        //public string EventType { get; set; } = string.Empty;
        //public string Id { get; set; } = string.Empty;
        //public string Date { get; set; } = string.Empty;
        //public string TimeOfCall { get; set; } = string.Empty;
        //public string StatusDescription { get; set; } = string.Empty;
        //public string StatusIcon { get; set; } = string.Empty;
        //public string StatusFilterLabel { get; set; } = string.Empty;
        //public string TypeDescription { get; set; } = string.Empty;
        //public string TypeIcon { get; set; } = string.Empty;
        //public string Location { get; set; } = string.Empty;
        //public string Updated { get; set; } = string.Empty;
    }
}
