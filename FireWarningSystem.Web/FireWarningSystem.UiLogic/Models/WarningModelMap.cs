using System.Text.Json;
using WarningClient.Models;

namespace FireWarningSystem.UiLogic.Models
{
    public static class WarningModelMap
    {
        public static IEnumerable<WarningModel> Map(IEnumerable<ActIncident> actIncidents)
        {
            return actIncidents.Select(x =>
            {
                double longitude = ParseDouble(x.Longitude);
                double latitude = ParseDouble(x.Latitude);
                return new WarningModel()
                {
                    StateType = "ACT",
                    Latitude = latitude,
                    Longitude = longitude,
                    Title = x.Title,
                    Description =
                    $@"
                    <tr><td>Agency:</td><td>{x.Agency}</td></tr>
                    <tr><td>Status:</td><td>{x.Status}</td></tr>
                    <tr><td>Region:</td><td>{x.Region}</td></tr>
                    <tr><td>Category:</td><td>{x.Type}</td></tr>"
                };
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<VicIncident> vicIncidents)
        {
            return vicIncidents.Select(x =>
            {
                return new WarningModel()
                {
                    StateType = "VIC",
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Title = x.Name,
                    Description =
                    $@"
                    <tr><td>Incident No:</td><td>{x.IncidentNo}</td></tr>
                    <tr><td>Origin Time:</td><td>{x.OriginDateTime}</td></tr>
                    <tr><td>Status:</td><td>{x.IncidentStatus}</td></tr>
                    <tr><td>Incident Type:</td><td>{x.IncidentType}</td></tr>
                    <tr><td>Category:</td><td>{x.Category1}</td></tr>
                    <tr><td>Sub Category:</td><td>{x.Category2}</td></tr>
                    <tr><td>Resource Count:</td><td>{x.ResourceCount}</td></tr>"
                };
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<NswFeature> nswWarnings)
        {
            return nswWarnings.Select(x =>
            {
                //handles the extraction of lat long from the terrible point structure of the NSW emergency API
                double longditude = x.Geometry.Coordinates == null ?
                    x.Geometry.Geometries!.First().Coordinates!.First() : x.Geometry.Coordinates.First();
                double latitude = x.Geometry.Coordinates == null ?
                  x.Geometry.Geometries!.First().Coordinates!.Last() : x.Geometry.Coordinates.Last();

                var item = new WarningModel()
                {
                    StateType = "NSW",
                    Latitude = latitude,
                    Longitude = longditude,
                    Title = x.Properties.Title,
                    Description = x.Properties.Description
                };

                return item;
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<NtIncident> ntIncidents)
        {
            return ntIncidents.Select(x =>
            {
                double latitude = 0;
                double longitude = 0;
                if (x.Geometry.Type == "Point")
                {
                    var coordinates = x.Geometry.Coordinates.Deserialize<List<double>>();
                    longitude = coordinates!.First();
                    latitude = coordinates!.Last();
                }
                else
                {
                    var coordinates = x.Geometry!.Coordinates.Deserialize<List<List<List<double>>>>();

                    longitude = coordinates!.First().Select(x => x.First()).Average();
                    latitude = coordinates!.First().Select(x => x.Last()).Average();
                }
                return new WarningModel()
                {
                    StateType = "NT",
                    Title = x.Properties.EventType,
                    Latitude = latitude,
                    Longitude = longitude,
                    Description =
                    $@"
                    <tr><td>Category:</td><td>{x.Properties.Category}</td></tr>
                    <tr><td>Status:</td><td>{x.Properties.Status}</td></tr>
                    <tr><td>Incident Status:</td><td>{x.Properties.IncidentStatus}</td></tr>
                    <tr><td>Last Update:</td><td>{x.Properties.LastUpdate}</td></tr>
                    <tr><td>Location:</td><td>{x.Properties.Location}</td></tr>
                    <tr><td>Alert Level:</td><td>{x.Properties.AlertLevel}</td></tr>"
                };
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<QldIncident> qldIncidents)
        {
            return qldIncidents.Select(x =>
            {
                var dateTimeOutput = string.Empty;
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                if (x.Properties.LastUpdate != null)
                {
                    dateTime = dateTime.AddMilliseconds(x.Properties.LastUpdate ?? 0.00).ToLocalTime();
                    dateTimeOutput = $"{dateTime: hh-mm-ss tt}";
                }

                return new WarningModel()
                {
                    StateType = "QLD",
                    Latitude = x.Properties.Latitude,
                    Longitude = x.Properties.Longitude,
                    Title = x.Properties.MasterIncidentNumber,
                    Description =
                    $@"
                    <tr><td>Type:</td><td>{x.Properties.GroupedType}</td></tr>
                    <tr><td>Last update:</td><td>{dateTimeOutput}</td></tr>
                    <tr><td>Status:</td><td>{x.Properties.CurrentStatus}</td></tr>
                    <tr><td>Location:</td><td>{x.Properties.Location}</td></tr>
                    <tr><td>Locality:</td><td>{x.Properties.Locality}</td></tr>
                    <tr><td>Jurastiction:</td><td>{x.Properties.Jurisdiction}</td></tr>
                    <tr><td>Vehicles Assigned:</td><td>{x.Properties.VehiclesAssigned}</td></tr>
                    <tr><td>Vehicles On Route:</td><td>{x.Properties.VehiclesOnRoute}</td></tr>
                    <tr><td>Vehicles On Scene:</td><td>{x.Properties.VehiclesOnScene}</td></tr>"
                };
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<SaIncident> saIncidents)
        {
            return saIncidents.Select(x =>
            {
                double latitude = 0;
                double longitude = 0;
                if (!string.IsNullOrEmpty(x.Location))
                {
                    var latLong = x.Location.Split(",");
                    latitude = ParseDouble(latLong[0]);
                    longitude = ParseDouble(latLong[1]);
                }

                return new WarningModel()
                {
                    StateType = "SA",
                    Latitude = latitude,
                    Longitude = longitude,
                    Title = x.IncidentNo,
                    Description =
                    $@"
                    <tr><td>Type:</td><td>{x.Type}</td></tr>
                    <tr><td>Date:</td><td>{x.Date}</td></tr>
                    <tr><td>Time:</td><td>{x.Time}</td></tr>
                    <tr><td>Status:</td><td>{x.Status}</td></tr>
                    <tr><td>Location Name:</td><td>{x.LocationName}</td></tr>
                    <tr><td>Region:</td><td>{x.Region}</td></tr>
                    <tr><td>FBD:</td><td>{x.FBD}</td></tr>
                    <tr><td>Resources:</td><td>{x.Resources}</td></tr>
                    <tr><td>Aircraft:</td><td>{x.Aircraft}</td></tr>"
                };
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<TasFeature> tasIncidents)
        {
            return tasIncidents.Select(x =>
            {
                double latitude = 0;
                double longitude = 0;
                var geo = x.Geometry.Geometries.First(X => X.Type == "Point");

                var coordinates = geo.Coordinates.Deserialize<List<double>>();
                longitude = coordinates!.First();
                latitude = coordinates!.Last();


                return new WarningModel()
                {
                    StateType = "TAS",
                    Latitude = latitude,
                    Longitude = longitude,
                    Title = x.Properties.Title,
                    Description =
                    $@"
                    <tr><td>Alert Level:</td><td>{x.Properties.AlertLevel}</td></tr>
                    <tr><td>Feed Type:</td><td>{x.Properties.FeedType}</td></tr>
                    <tr><td>Status:</td><td>{x.Properties.Status}</td></tr>
                    <tr><td>Address:</td><td>{x.Properties.Address}</td></tr>"
                };
            });
        }

        public static IEnumerable<WarningModel> Map(IEnumerable<WaIncident> waIncidents)
        {
            return waIncidents.Select(x =>
            {
                return new WarningModel()
                {
                    StateType = "WA",
                    Latitude = x.Location.Latitude,
                    Longitude = x.Location.Longitude,
                    Title = x.Name,
                    Description =
                    $@"
                    <tr><td>Type:</td><td>{x.IncidentType}</td></tr>
                    <tr><td>Status:</td><td>{x.IncidentStatus}</td></tr>
                    <tr><td>Location:</td><td>{x.Location.Value}</td></tr>
                    <tr><td>Last Updated:</td><td>{x.UpdatedDateTime:hh-mm-ss}</td></tr>"
                };

            });
        }

        private static double ParseDouble(string value)
        {
            return double.TryParse(value?.Trim(), out double result) ? result : 0.0;
        }
    }
}

