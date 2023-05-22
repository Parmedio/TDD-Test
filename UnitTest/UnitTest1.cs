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

            var result = _sut.AssembleGtin(input);

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedPrice, result.Price);
        }

        [Fact]
        public void AssembleVariants()
        {
            var userInput = new List<string>
            {
                "G1;V1;P1;100",
                "G2;V1;P1;100",
                "G3;V2;P1;100",
                "G4;V2;P1;100"
            };
            var expectedFirstName = "V1";
            var expectedFirstPrice = 0;

            var expectedSecondName = "V2";
            var expectedSecondPrice = 0;

            var expectedGtinsLength = 2;
            var expectedGtinPrice = 100;

            var expectedFirsrGtinName = "G1";
            var expectedSecondGtinName = "G2";
            var expectedThirdGtinName = "G3";
            var expectedFourthGtinName = "G4";


            var result = _sut.AssembleVariants(userInput);

            Assert.Equal(expectedFirstName, result[0].Name);
            Assert.Equal(expectedSecondName, result[1].Name);

            Assert.Equal(expectedFirstPrice, result[0].Price);
            Assert.Equal(expectedSecondPrice, result[1].Price);

            Assert.Equal(expectedGtinsLength, result[0].Gtins.Count);
            Assert.Equal(expectedGtinsLength, result[1].Gtins.Count);

            Assert.Equal(expectedFirsrGtinName, result[0].Gtins[0].Name);
            Assert.Equal(expectedSecondGtinName, result[0].Gtins[1].Name);
            Assert.Equal(expectedThirdGtinName, result[1].Gtins[0].Name);
            Assert.Equal(expectedFourthGtinName, result[1].Gtins[1].Name);

            Assert.Equal(expectedGtinPrice, result[0].Gtins[0].Price);
            Assert.Equal(expectedGtinPrice, result[0].Gtins[1].Price);
            Assert.Equal(expectedGtinPrice, result[1].Gtins[0].Price);
            Assert.Equal(expectedGtinPrice, result[1].Gtins[1].Price);
        }
    }
}