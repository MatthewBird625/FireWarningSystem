using System.Text.Json.Serialization;

namespace WarningClient.Models
{
    public class SaIncident
    {
        public string IncidentNo { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        [JsonPropertyName("Location_name")]
        public string LocationName { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FBD { get; set; } = string.Empty;
        public int Resources { get; set; }
        public int Aircraft { get; set; }
        public string Location { get; set; } = string.Empty;

        //UNUSED API PROPERTIES - commented out for more reliability.

        // public string Message { get; set; } = string.Empty;
        //[JsonPropertyName("Message_link")]
        //public string MessageLink { get; set; } = string.Empty;
        //    public int Level { get; set; }
    }
}
