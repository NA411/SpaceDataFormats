using EngineeringUnits;

namespace NickSpace.SpaceDataFormats.Ussf
{
    public interface ISgp4Elements
    {
        Angle ArgumentOfPerigee { get; set; }
        double DragTerm { get; set; }
        double Eccentricity { get; set; }
        DateTime Epoch { get; set; }
        RotationalSpeed FirstDerivativeOfMeanMotion { get; set; }
        Angle Inclination { get; set; }
        Angle MeanAnomy { get; set; }
        TimeSpan MeanMotion { get; set; }
        Angle RightAscensionOfTheAscendingNode { get; set; }
        double SecondDerivativeOfMeanMotion { get; set; }
    }
}