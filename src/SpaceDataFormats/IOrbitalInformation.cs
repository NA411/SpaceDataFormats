using EngineeringUnits;

namespace NickSpace.SpaceDataFormats
{
    public interface IOrbitalInformation
    {
        Length Apoapsis { get; set; }
        CentralBody CentralBody { get; set; }
        Length Periapsis { get; set; }
        TimeSpan Period { get; set; }
        Length SemiMajorAxis { get; set; }
    }
}