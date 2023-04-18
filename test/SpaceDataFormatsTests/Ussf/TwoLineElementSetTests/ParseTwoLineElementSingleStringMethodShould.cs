using NickSpace.SpaceDataFormats.Ussf;

namespace NickSpace.SpaceDataFormatsTests.Ussf.TwoLineElementSetTests
{
    [TestClass]
    public class ParseTwoLineElementSingleStringMethodShould
    {
        [TestMethod]
        public void NotParseNulls()
        {
            //-- Assemble
            const string? input = null;
            _ = input;
            //-- Act
            //-- Assert
            Assert.Inconclusive();
        }
    }
}
