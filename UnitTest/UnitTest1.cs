using Xunit;
using TDD_Test;
using TDD_Test.models;

namespace UnitTest
{
    public class UnitTest1
    {
        private readonly Services _sut;

        public UnitTest1()
        {
            _sut = new Services();
        }

        [Fact]
        public void AssembleGtin()
        {
            var input = "G1;V1;P1;100";
            var expectedName = "G1";
            var expectedPrice = 100;

            var result = _sut.AssembleGitin(input);

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedPrice, result.Price);
        }

        [Fact]
        public void AssembleVariant()
        {
            var input = "G1;V1;P1;100";
            var expectedName = "V1";
            var expectedPrice = 0;
            var expectedGtinsLength = 1;
            var expectedFirsrGtinPrice = 100;
            var expectedFirsrGtinName = "G1";


            var result = _sut.AssembleVariant(input);

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedPrice, result.Price);
            Assert.Equal(expectedGtinsLength, result.Gtins.Count);
            Assert.Equal(expectedFirsrGtinPrice, result.Gtins[0].Name);
            Assert.Equal(expectedFirsrGtinName, result.Gtins[0].Price);
        }
    }
}