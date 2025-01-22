using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarningClient.Models
{
    public class QLdFeatureCollection
    {
      //  public string Type { get; set; } = string.Empty;
        public List<QldIncident> Features { get; set; } = new List<QldIncident>();
    }

    public class QldIncident
    {
       // public string Type { get; set; } = string.Empty;
        //public int Id { get; set; }
        public Properties Properties { get; set; } = new Properties();
    }

    public class Properties
    {
        [JsonPropertyName("Master_Incident_Number")]
        public string MasterIncidentNumber { get; set; } = string.Empty;
        public long? LastUpdate { get; set; }
        public string CurrentStatus { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Jurisdiction { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int VehiclesAssigned { get; set; }
        public int VehiclesOnRoute { get; set; }
        public int VehiclesOnScene { get; set; }
        public string GroupedType { get; set; } = string.Empty;
        public string Locality { get; set; } = string.Empty;


        //UNUSED API PROPERTIES - commented out for more reliability.

        // public int ObjectId { get; set; }
        //   public long FmeTimestamp { get; set; }
        //  public long ResponseDate { get; set; }
    }
}
