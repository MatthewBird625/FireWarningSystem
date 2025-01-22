using System.Text.Json.Serialization;
using System.Text.Json;

namespace WarningClient.Models
{
    public class NtIncidentResponse
    {
        public NtIncidents Incidents { get; set; } = new NtIncidents();
    }

    public class NtIncidents
    {
        public List<NtIncident> Features { get; set; } = new List<NtIncident>();
    }

    public class NtIncident
    {
        public Geometry Geometry { get; set; } = new Geometry();
        public NtIncidentProperties Properties { get; set; } = new NtIncidentProperties();
    }

    public class Geometry
    {
        public string Type { get; set; } = string.Empty;

        public JsonElement Coordinates { get; set; }
    }

    public class NtIncidentProperties
    {
        [JsonPropertyName("_category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("_status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("_eventtype")]
        public string EventType { get; set; } = string.Empty;

        [JsonPropertyName("_location")]
        public string Location { get; set; } = string.Empty;

        [JsonPropertyName("_lastupdate")]
        public string LastUpdate { get; set; } = string.Empty;

        [JsonPropertyName("Status")]
        public string IncidentStatus { get; set; } = string.Empty;

        [JsonPropertyName("Alert Level")]
        public string AlertLevel { get; set; } = string.Empty;

        //UNUSED API PROPERTIES - commented out for more reliability.

        //[JsonPropertyName("_dateclosed")]
        //public string DateClosed { get; set; } = string.Empty;

        //[JsonPropertyName("_datenotified")]
        //public string DateNotified { get; set; } = string.Empty;

        //[JsonPropertyName("Fire Type")]
        //public string FireType { get; set; } = string.Empty;

        //[JsonPropertyName("Current Situation")]
        //public string CurrentSituation { get; set; } = string.Empty;

        //[JsonPropertyName("Risks")]
        //public string Risks { get; set; } = string.Empty;

        //[JsonPropertyName("What to do")]
        //public string WhatToDo { get; set; } = string.Empty;

        //[JsonPropertyName("Advice to the Public")]
        //public string AdviceToThePublic { get; set; } = string.Empty;

        //[JsonPropertyName("Responsible Agency")]
        //public string ResponsibleAgency { get; set; } = string.Empty;

        //[JsonPropertyName("Last Update")]
        //public string LastUpdateFormatted { get; set; } = string.Empty;
    }
}
