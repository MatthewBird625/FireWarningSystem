namespace WarningClient.Models
{
    public class NswFeatureCollection
    {
        public List<NswFeature> Features { get; set; } = new List<NswFeature>();

        //public string Type { get; set; } = string.Empty;
    }

    public class NswFeature
    {
        public NswGeometry Geometry { get; set; } = new NswGeometry();
        public NswProperties Properties { get; set; } = new NswProperties();

        // public string Type { get; set; } = string.Empty;
    }

    public class NswGeometry
    {
        public List<NswGeometries>? Geometries { get; set; }
        public IEnumerable<double>? Coordinates { get; set; }

        //   public string Type { get; set; } = string.Empty;
    }

    public class NswGeometries
    { 
        public IEnumerable<double>? Coordinates { get; set; }

        //public string Type { get; set; } = string.Empty;
        //public IEnumerable<IEnumerable<double>>? Polygon {  get; set; }
    }


    public class NswProperties
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        //UNUSED API PROPERTIES - commented out for more reliability.


        //public string Link { get; set; } = string.Empty;
        //public string Category { get; set; } = string.Empty;
        //public string Guid { get; set; } = string.Empty;
        //public string GuidIsPermaLink { get; set; } = string.Empty;
        //public string PubDate { get; set; } = string.Empty;
    }
}
