using System.ComponentModel.DataAnnotations;
using UnitsNet;

namespace NickSpace.SpaceDataFormats.Ussf
{
    /// <summary>
    /// https://web.archive.org/web/20000301052035/http://spaceflight.nasa.gov/realdata/sightings/SSapplications/Post/JavaSSOP/SSOP_Help/tle_def.html
    /// https://celestrak.org/NORAD/documentation/tle-fmt.php
    /// https://www.space-track.org/documentation#tle
    /// </summary>
    public class TwoLineElementSet : IParseable<TwoLineElementSet>, ISgp4Elements, IOrbitalInformation, IIsValidatable
    {
        #region Fields
        private readonly string _line0 = string.Empty;
        private readonly string _line1 = string.Empty;
        private readonly string _line2 = string.Empty;
        #endregion
        #region Properties
        public uint SatelliteNumber { get; set; }
        public char Classification { get; set; }
        public string InternationalDesignator { get; set; } = string.Empty;
        public DateTime Epoch { get; set; }
        /// <summary>
        /// Also called the first derivative of mean motion, the ballistic coefficient is the daily rate of change in the number of revs the object completes each day, divided by 2. Units are revs/day. This is "catch all" drag term used in the Simplified General Perturbations (SGP4) USSPACECOM predictor.
        /// </summary>
        public double FirstDerivativeOfMeanMotion { get; set; }
        /// <summary>
        /// The second derivative of mean motion is a second order drag term in the SGP4 predictor used to model terminal orbit decay. It measures the second time derivative in daily mean motion, divided by 6. Units are revs/day^3. A leading decimal must be applied to this value. The last two characters define an applicable power of 10. (12345-5 = 0.0000012345).
        /// </summary>
        public double SecondDerivativeOfMeanMotion { get; set; }
        /// <summary>
        /// Also called the radiation pressure coefficient (or BSTAR), the parameter is another drag term in the SGP4 predictor. Units are earth radii^-1. The last two characters define an applicable power of 10. Do not confuse this parameter with "B-Term", the USSPACECOM special perturbations factor of drag coefficient, multiplied by reference area, divided by weight.
        /// </summary>
        public double DragTerm { get; set; }
        public ushort ElementNumber { get; set; }
        public char ElementSetType { get; set; }
        /// <summary>
        /// The angle between the equator and the orbit plane. The value provided is the TEME mean inclination.
        /// </summary>
        public Angle Inclination { get; set; }
        /// <summary>
        /// The angle between vernal equinox and the point where the orbit crosses the equatorial plane (going north). The value provided is the TEME mean right ascension of the ascending node.
        /// </summary>
        public Angle RightAscensionOfTheAscendingNode { get; set; }
        /// <summary>
        /// A constant defining the shape of the orbit (0=circular, Less than 1=elliptical). The value provided is the mean eccentricity. A leading decimal must be applied to this value.
        /// </summary>
        public double Eccentricity { get; set; }
        /// <summary>
        /// The angle between the ascending node and the orbit's point of closest approach to the earth (perigee). The value provided is the TEME mean argument of perigee.
        /// </summary>
        public Angle ArgumentOfPerigee { get; set; }
        /// <summary>
        /// The angle, measured from perigee, of the satellite location in the orbit referenced to a circular orbit with radius equal to the semi-major axis.
        /// </summary>
        public Angle MeanAnomy { get; set; }
        /// <summary>
        /// The value is the mean number of orbits per day the object completes. There are 8 digits after the decimal, leaving no trailing space(s) when the following element exceeds 9999.
        /// </summary>
        public TimeSpan MeanMotion { get; set; }
        public ushort RevolutionNumberAtEpoch { get; set; }
        public Length SemiMajorAxis { get; set; }
        public Length Apoapsis { get; set; }
        public Length Periapsis { get; set; }
        public TimeSpan Period { get; set; }
        public CentralBody CentralBody { get; set; } = CentralBody.Earth;
        public bool IsValid {get; private set;}
        #endregion
        #region Constructors
        #endregion
        #region Public Methods
        /// <summary>
        /// https://www.c-sharpcorner.com/article/c-sharp-string-object-impact-on-performance/
        /// </summary>
        /// <param name="text"></param>
        /// <param name="twoLineElement"></param>
        /// <returns></returns>
        public static bool TryParse(string text, out TwoLineElementSet twoLineElement)
        {
            try
            {
                twoLineElement = Parse(text);
            }
            catch (Exception ex)
            {
                _ = ex;
                twoLineElement = new TwoLineElementSet
                {
                    IsValid = false
                };
                return false;
            }
            twoLineElement.Validate();
            return true;
        }
        public static bool TryParse(Stream stream, out TwoLineElementSet twoLineElement)
        {
            try
            {
                using StreamReader reader = new(stream);
                twoLineElement = Parse(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                _ = ex;
                twoLineElement = new TwoLineElementSet();
                return false;
            }
            return true;
        }
        public static TwoLineElementSet Parse(string text)
        {
            var tle = new TwoLineElementSet
            {
                Epoch = DateTime.Parse(text[0..1])
            };
            return tle;
        }
        public static TwoLineElementSet Parse(Stream stream)
        {
            using StreamReader reader = new(stream);
            return Parse(reader.ReadToEnd());
        }
        public static bool TryConvertAlphaFiveToSatelliteNumber(string satelliteDesignation, out uint satelliteNumber)
        {
            satelliteNumber = default;
            const int lengthOfAlphaFive = 5;
            if (string.IsNullOrWhiteSpace(satelliteDesignation))
                return false;
            if (satelliteDesignation.Length < lengthOfAlphaFive ||  satelliteDesignation.Length > lengthOfAlphaFive)
                return false;
            if (!char.IsLetter(satelliteDesignation[0]))
                return false;
            if (AlphaFiveLookup.AlphaToNumTable.TryGetValue(char.ToUpperInvariant(Convert.ToChar(satelliteDesignation[..1])), out ushort value))
            {
                satelliteNumber = Convert.ToUInt32(value * 10_000) + uint.Parse(satelliteDesignation[1..]);
                return true;
            }
            return false;
        }
        public static bool TryConvertSatelliteNumberToAlphaFive(int satelliteNumber, out string alphaFiveString)
        {
            alphaFiveString = string.Empty;
            const int minAlphaFiveSatelliteNumber = 10_000;
            const int maxAlphaFiveSatelliteNumber = 399_999;
            if (satelliteNumber < minAlphaFiveSatelliteNumber || satelliteNumber > maxAlphaFiveSatelliteNumber)
                return false;
            ReadOnlySpan<char> satNumberSpan = Convert.ToString(satelliteNumber);
            if (AlphaFiveLookup.NumToAlphaTable.TryGetValue(Convert.ToUInt16(satelliteNumber / 10_000), out char alphaChar))
            {
                alphaFiveString = string.Concat(alphaChar,satNumberSpan.Slice(satNumberSpan.Length - 4, 4).ToString());
                return true;
            }
            return false;
        }
        private void Validate()
        {
            IsValid = true;
        }
        #endregion
        #region Override Methods
        public override string ToString() => string.Join(Environment.NewLine, _line0, _line1, _line2);
        #endregion
        #region Private Methods
        #endregion
    }
}
