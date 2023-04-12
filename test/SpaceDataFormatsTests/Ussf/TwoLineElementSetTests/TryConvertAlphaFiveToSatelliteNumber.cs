using NickSpace.SpaceDataFormats.Ussf;

namespace NickSpace.SpaceDataFormatsTests.Ussf.TwoLineElementSetTests
{
    [TestClass]
    public class TryConvertAlphaFiveToSatelliteNumber
    {
        [DataTestMethod]
        [DataRow("A1246")]
        [DataRow("T2033")]
        [DataRow("G6463")]
        public void ShouldReturnTrueWithValidConversion(string satelliteDesignation)
        {
            //-- Assemble
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(satelliteDesignation, out uint _);
            //-- Assert
            Assert.IsTrue(actualResult);
        }
        [DataTestMethod]
        [DataRow("A1246",101_246)]
        [DataRow("T2033",272_033)]
        [DataRow("G6463",166_463)]
        public void ShouldConvertAlphaFiveToExpectedSatelliteNumbers(string input, int expectedResult)
        {
            //-- Assemble
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(expectedResult == actualResult);
        }
        [DataTestMethod]
        [DataRow("I1246")]
        [DataRow("O2033")]
        public void ShouldReturnFalseWithInvalidAlphaFiveString(string input)
        {
            //-- Assemble
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [DataTestMethod]
        [DataRow("I1246")]
        [DataRow("O2033")]
        public void ShouldConvertInvalidAlphaFiveToDefaultUInt(string input)
        {
            //-- Assemble
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint satelliteNumber);
            //-- Assert
            Assert.IsTrue(satelliteNumber == default);
        }
        [TestMethod]
        public void ShouldReturnFalseWhenAlphaFiveStringDoesNotStartWithAlphaChar()
        {
            //-- Assemble
            const string input = "34324";
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [DataTestMethod]
        [DataRow("D14232")]
        [DataRow("A123")]
        [DataRow("B12")]
        [DataRow("C1")]
        public void ShouldReturnFalseWhenStringIsNotFiveDigits(string inputStr)
        {
            //-- Assemble
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(inputStr, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ShouldReturnFalseWhenStringIsNull()
        {
            //-- Assemble
            const string? input = null;
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input!, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ShouldReturnFalseWhenStringIsEmpty()
        {
            string input = string.Empty;
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ShouldReturnFalseWhenStringIsWhiteSpace()
        {
            const string input = " ";
            //-- Act
            var actualResult = TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ShouldReturnDefaultUIntWhenAlphaFiveStringDoesNotStartWithAlphaChar()
        {
            //-- Assemble
            const string input = "34324";
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [DataTestMethod]
        [DataRow("D14232")]
        [DataRow("A123")]
        [DataRow("B12")]
        [DataRow("C1")]
        public void ShouldReturnDefaultUIntWhenStringIsNotFiveDigits(string inputStr)
        {
            //-- Assemble
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(inputStr, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [TestMethod]
        public void ShouldReturnDefaultUIntWhenStringIsNull()
        {
            //-- Assemble
            const string? input = null;
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input!, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [TestMethod]
        public void ShouldReturnDefaultUIntWhenStringIsEmpty()
        {
            string input = string.Empty;
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [TestMethod]
        public void ShouldReturnDefaultUIntWhenStringIsWhiteSpace()
        {
            const string input = " ";
            //-- Act
            TwoLineElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
    }
}
