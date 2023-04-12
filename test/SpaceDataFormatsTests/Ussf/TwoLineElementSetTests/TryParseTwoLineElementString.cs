using NickSpace.SpaceDataFormats.Ussf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickSpace.SpaceDataFormatsTests.Ussf.TwoLineElementSetTests
{
    [TestClass]
    public class TryParseTwoLineElementString
    {
        [TestMethod]
        public void ShouldNotParseNull()
        {
            //-- Assemble
            const string? input = null;
            //-- Act
            //-- Assert
            Assert.Inconclusive();
        }
    }
}
