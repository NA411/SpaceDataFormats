using NickSpace.SpaceDataFormats.Ussf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickSpace.SpaceDataFormatsTests.Ussf.TwoLineElementSetTests
{
    [TestClass]
    public class TryParseTwoLineElementSingleStringMethodShould
    {
        [TestMethod]
        public void NotParseNull()
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
