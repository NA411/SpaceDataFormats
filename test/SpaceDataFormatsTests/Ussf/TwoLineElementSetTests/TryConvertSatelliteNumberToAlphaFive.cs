using NickSpace.SpaceDataFormats.Ussf;

namespace NickSpace.SpaceDataFormatsTests.Ussf.TwoLineElementSetTests
{
    [TestClass]
    public class TryConvertSatelliteNumberToAlphaFive
    {
        [DataTestMethod]
        [DataRow(101_246)]
        [DataRow(272_033)]
        [DataRow(166_463)]
        public void ShouldReturnTrueWithValidConversion(int satelliteNumber)
        {
            //-- Assemble
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertSatelliteNumberToAlphaFive(satelliteNumber, out string _);
            //-- Assert
            Assert.IsTrue(actualResult);
        }
        [DataTestMethod]
        [DataRow("A1246", 101_246)]
        [DataRow("T2033", 272_033)]
        [DataRow("G6463", 166_463)]
        public void ShouldConvertSatelliteNumnberToAlphaFive(string expectedResult, int satelliteNumber)
        {
            //-- Assemble
            //-- Act
            TwoLineElementSet.TryConvertSatelliteNumberToAlphaFive(satelliteNumber, out string actualResult);
            //-- Assert
            Assert.IsTrue(actualResult.Equals(expectedResult, StringComparison.Ordinal));
        }
        [DataTestMethod]
        [DataRow(99000)]
        [DataRow(340_000)]
        [DataRow(0)]
        public void ShouldReturnFalseWithInvalidSatelliteNumber(int satelliteNumber)
        {
            //-- Assemble
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertSatelliteNumberToAlphaFive(satelliteNumber, out string _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [DataTestMethod]
        [DataRow(99000)]
        [DataRow(340_000)]
        [DataRow(0)]
        public void ShouldConvertInvalidSatelliteNumberToEmptyString(int satelliteNumber)
        {
            //-- Assemble
            //-- Act
            TwoLineElementSet.TryConvertSatelliteNumberToAlphaFive(satelliteNumber, out string actualResult);
            _ = satelliteNumber;
            //-- Assert
            Assert.IsTrue(actualResult.Equals(string.Empty,StringComparison.Ordinal));
        }
    }
}