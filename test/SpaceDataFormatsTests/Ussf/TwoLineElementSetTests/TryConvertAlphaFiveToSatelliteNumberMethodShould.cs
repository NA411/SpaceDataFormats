using NickSpace.SpaceDataFormats.Ussf;

namespace NickSpace.SpaceDataFormatsTests.Ussf.TwoLineElementSetTests
{
    [TestClass]
    public class TryConvertAlphaFiveToSatelliteNumberMethodShould
    {
        [DataTestMethod]
        [DataRow("A1246")]
        [DataRow("T2033")]
        [DataRow("G6463")]
        public void ReturnTrueWithValidConversion(string satelliteDesignation)
        {
            //-- Assemble
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(satelliteDesignation, out uint _);
            //-- Assert
            Assert.IsTrue(actualResult);
        }
        [DataTestMethod]
        [DataRow("A1246",101_246)]
        [DataRow("T2033",272_033)]
        [DataRow("G6463",166_463)]
        public void ConvertAlphaFiveToExpectedSatelliteNumbers(string input, int expectedResult)
        {
            //-- Assemble
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(expectedResult == actualResult);
        }
        [DataTestMethod]
        [DataRow("I1246")]
        [DataRow("O2033")]
        public void ReturnFalseWithInvalidAlphaFiveString(string input)
        {
            //-- Assemble
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [DataTestMethod]
        [DataRow("I1246")]
        [DataRow("O2033")]
        public void ConvertInvalidAlphaFiveToDefaultUInt(string input)
        {
            //-- Assemble
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint satelliteNumber);
            //-- Assert
            Assert.IsTrue(satelliteNumber == default);
        }
        [TestMethod]
        public void ReturnFalseWhenAlphaFiveStringDoesNotStartWithAlphaChar()
        {
            //-- Assemble
            const string input = "34324";
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [DataTestMethod]
        [DataRow("D14232")]
        [DataRow("A123")]
        [DataRow("B12")]
        [DataRow("C1")]
        public void ReturnFalseWhenInputStringIsNotFiveDigits(string inputStr)
        {
            //-- Assemble
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(inputStr, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ReturnFalseWhenInputStringIsNull()
        {
            //-- Assemble
            const string? input = null;
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(input!, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ReturnFalseWhenInputStringIsEmpty()
        {
            string input = string.Empty;
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ReturnFalseWhenInputStringIsWhiteSpace()
        {
            const string input = " ";
            //-- Act
            var actualResult = ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint _);
            //-- Assert
            Assert.IsFalse(actualResult);
        }
        [TestMethod]
        public void ReturnDefaultUIntWhenAlphaFiveInputStringDoesNotStartWithAlphaChar()
        {
            //-- Assemble
            const string input = "34324";
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [DataTestMethod]
        [DataRow("D14232")]
        [DataRow("A123")]
        [DataRow("B12")]
        [DataRow("C1")]
        public void ReturnDefaultUIntWhenInputAlphaFiveStringIsNotFiveChars(string inputStr)
        {
            //-- Assemble
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(inputStr, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [TestMethod]
        public void ReturnDefaultUIntWhenInputStringIsNull()
        {
            //-- Assemble
            const string? input = null;
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(input!, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [TestMethod]
        public void ReturnDefaultUIntWhenInputStringIsEmpty()
        {
            string input = string.Empty;
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
        [TestMethod]
        public void ReturnDefaultUIntWhenInputStringIsWhiteSpace()
        {
            const string input = " ";
            //-- Act
            ElementSet.TryConvertAlphaFiveToSatelliteNumber(input, out uint actualResult);
            //-- Assert
            Assert.IsTrue(actualResult == default);
        }
    }
}
