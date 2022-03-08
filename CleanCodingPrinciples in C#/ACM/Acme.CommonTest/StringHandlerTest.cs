using System;
using Xunit;
using Acme.Common;

namespace Acme.CommonTest
{
    public class StringHandlerTest
    {
        [Fact]
        public void InsertSpacesTestValid()
        {
            var source = "SonicTheHedgehog";
            
            var expected = "Sonic The Hedgehog";
            var actual = StringHandler.InsertSpaces(source);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertSpacesTestWithExistingSpace()
        {
            var source = "Sonic TheHedgehog";

            var expected = "Sonic The Hedgehog";
            var actual = StringHandler.InsertSpaces(source);

            Assert.Equal(expected, actual);
        }
    }
}
