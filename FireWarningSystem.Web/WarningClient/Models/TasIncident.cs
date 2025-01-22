using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarningClient.Models
{
    public class TasFeatureCollection
    {
        [JsonPropertyName("features")]
        public List<TasFeature> Features { get; set; } = new List<TasFeature>();
    }

    public class TasFeature
    {
        [JsonPropertyName("geometry")]
        public TasGeometry Geometry { get; set; } = new TasGeometry();

        [JsonPropertyName("properties")]
        public TasFeatureProperties Properties { get; set; } = new TasFeatureProperties();
    }

    public class TasGeometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("geometries")]
        public List<TasGeometry> Geometries { get; set; } = new List<TasGeometry>();

        [JsonPropertyName("coordinates")]
        public JsonElement Coordinates { get; set; } // Can be array or nested structure
    }

    public class TasFeatureProperties
    {
        //[JsonPropertyName("id")]
        //public string Id { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("alertLevel")]
        public string AlertLevel { get; set; } = string.Empty;

        [JsonPropertyName("feedType")]
        public string FeedType { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}
