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
            var input = new string[] {"G1", "V1", "P1", "100"};
            var expectedName = "G1";
            var expectedPrice = 100;

            var result = _sut.AssembleGtin(input);

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedPrice, result.Price);
        }

        [Fact]
        public void FindLowerPrice()
        {
            var userInput = new List<string>
            {
                "G1;V1;P1;50",
                "G2;V1;P1;60",
                "G3;V2;P1;70",
                "G4;V2;P1;80"
            };

            var expectedFirstGtins = _sut.AssembleVariants(userInput)[0].Gtins.Cast<ILowerPrice>().ToList();
            var expectedSecondGtins = _sut.AssembleVariants(userInput)[1].Gtins.Cast<ILowerPrice>().ToList();
            var expectedVariants = _sut.AssembleVariants(userInput).Cast<ILowerPrice>().ToList();

            var result01 = _sut.FindLowestPrice(expectedFirstGtins);
            var result02 = _sut.FindLowestPrice(expectedSecondGtins);
            var result03 = _sut.FindLowestPrice(expectedVariants);

            Assert.Equal(50, result01);
            Assert.Equal(70, result02);
            Assert.Equal(50, result03);
        }

        [Fact]
        public void AssembleVariants()
        {
            var userInput = new List<string>
            {
                "G1;V1;P1;50",
                "G2;V1;P1;60",
                "G3;V2;P1;70",
                "G4;V2;P1;80"
            };

            var result = _sut.AssembleVariants(userInput);

            Assert.Equal("V1", result[0].Name);
            Assert.Equal("V2", result[1].Name);

            Assert.Equal(50, result[0].Price);
            Assert.Equal(70, result[1].Price);

            Assert.Equal(2, result[0].Gtins.Count);
            Assert.Equal(2, result[1].Gtins.Count);

            Assert.Equal("G1", result[0].Gtins[0].Name);
            Assert.Equal("G2", result[0].Gtins[1].Name);
            Assert.Equal("G3", result[1].Gtins[0].Name);
            Assert.Equal("G4", result[1].Gtins[1].Name);

            Assert.Equal(50, result[0].Gtins[0].Price);
            Assert.Equal(60, result[0].Gtins[1].Price);
            Assert.Equal(70, result[1].Gtins[0].Price);
            Assert.Equal(80, result[1].Gtins[1].Price);
        }

        [Fact]
        public void AssembleProduct()
        {
            var userInput = new List<string>
            {
                "G1;V1;P1;50",
                "G2;V1;P1;60",
                "G3;V2;P1;70",
                "G4;V2;P1;80"
            };

            var expectedName = "P1";
            var expectedPrice = 50;
            var expectedVariants = _sut.AssembleVariants(userInput);

            var result = _sut.AssembleProduct(userInput);

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedPrice, result.Price);
            Assert.Equal(expectedVariants[0].Gtins[0].Name, result.Variants[0].Gtins[0].Name);
        }
    }
}