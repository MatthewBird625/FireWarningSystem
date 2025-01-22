using System.Text.Json;
using System.Text.Json.Serialization;

namespace WarningClient.Models
{
    public class WaIncidents
    {
        [JsonPropertyName("incidents")]
        public List<WaIncident> Incidents { get; set; } = new List<WaIncident>();
    }

    public class Location
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public class WaIncident
    {
        [JsonPropertyName("updated-date-time")]
        public DateTime UpdatedDateTime { get; set; }
        [JsonPropertyName("incident-type")]
        public string IncidentType { get; set; } = string.Empty;

        [JsonPropertyName("incident-status")]
        public string IncidentStatus { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("location")]
        public Location Location { get; set; } = new Location();


        //UNUSED API PROPERTIES - commented out for more reliability.

        //[JsonPropertyName("published-date-time")]
        //public DateTime PublishedDateTime { get; set; }
        //[JsonPropertyName("cad-id")]
        //public string CadId { get; set; } = string.Empty;
        //[JsonPropertyName("dfes-regions")]
        //public List<string> DfesRegions { get; set; } = new List<string>();
        //[JsonPropertyName("id")]
        //public string Id { get; set; } = string.Empty;
        //[JsonPropertyName("event")]
        //public string Event { get; set; } = string.Empty;
        //[JsonPropertyName("geo-source")]
        //public GeoSource GeoSource { get; set; } = new GeoSource();
        //[JsonPropertyName("suburbs")]
        //public List<string> Suburbs { get; set; } = new List<string>();
        //[JsonPropertyName("start-date-time")]
        //public DateTime StartDateTime { get; set; }
        //[JsonPropertyName("entityType")]
        //public string EntityType { get; set; } = string.Empty;
        //[JsonPropertyName("entitySubType")]
        //public string EntitySubType { get; set; } = string.Empty;
        //[JsonPropertyName("lga")]
        //public List<string> Lga { get; set; } = new List<string>();
        //[JsonPropertyName("publishing-status")]
        //public string PublishingStatus { get; set; } = string.Empty;
    }

    //public class GeoSource
    //{
    //    [JsonPropertyName("features")]
    //    public List<Feature> Features { get; set; } = new List<Feature>();

    //    [JsonPropertyName("type")]
    //    public string Type { get; set; } = string.Empty;
    //}

    //public class Feature
    //{
    //    [JsonPropertyName("geometry")]
    //    public Geometry Geometry { get; set; } = new Geometry();

    //    [JsonPropertyName("id")]
    //    public string Id { get; set; } = string.Empty;

    //    [JsonPropertyName("type")]
    //    public string Type { get; set; } = string.Empty;

    //    [JsonPropertyName("properties")]
    //    public Properties Properties { get; set; } = new Properties();
    //}

    //public class Geometry
    //{
    //    [JsonPropertyName("coordinates")]
    //    public JsonElement Coordinates { get; set; } 

    //    [JsonPropertyName("type")]
    //    public string Type { get; set; } = string.Empty;
    //}

    //public class Properties
    //{
    //    [JsonPropertyName("icon-name")]
    //    public string IconName { get; set; } = string.Empty;

    //    [JsonPropertyName("stroke-width")]
    //    public int StrokeWidth { get; set; }

    //    [JsonPropertyName("fill")]
    //    public string Fill { get; set; } = string.Empty;

    //    [JsonPropertyName("stroke")]
    //    public string Stroke { get; set; } = string.Empty;

    //    [JsonPropertyName("fill-opacity")]
    //    public double FillOpacity { get; set; }
    //}
}
