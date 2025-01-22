namespace FireWarningSystem.UiLogic.Models
{
    public static class WarningModelExtension
    {
        public static IEnumerable<WarningModel> WhereInvalidCoordinates(this IEnumerable<WarningModel> warnings)
        {
            return warnings.Where(
                x => !(x.Latitude >= -90 && x.Latitude <= 90) ||
                    !(x.Longitude >= -180 && x.Longitude <= 180) ||
                    //we do not accept 0, 0 coordinates because its the default double values and is https://en.wikipedia.org/wiki/Null_Island
                    (x.Latitude == 0 && x.Longitude == 0)

                );
        }
    }
}
