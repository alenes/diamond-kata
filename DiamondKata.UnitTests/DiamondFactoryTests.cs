using System.Linq;
using DiamondKata.ConsoleApp;
using FluentAssertions;
using Xunit;

namespace DiamondKata.UnitTests
{
    public class DiamondFactoryTests
    {
        private readonly DiamondFactory _sut;

        public DiamondFactoryTests()
        {
            _sut = new DiamondFactory();
        }
        
        [Fact]
        public void ShouldCreateDiamondCharacters_GivenDiamondMidpoint()
        {
            //Arrange
            var midpoint = 'C';

            //Act
            var result = _sut.Create(midpoint);

            //Assert
            var characters = result.Select(l => l.Replace("_", string.Empty)[0]).ToArray();
            var resultString = new string(characters);
            resultString.Should().Be("ABCBA");
        }
        
        [Fact]
        public void ShouldCreateDiamondEdgeLines_GivenDiamondMidpoint()
        {
            //Arrange
            var midpoint = 'C';

            //Act
            var result = _sut.Create(midpoint);

            //Assert
            var top = result.First();
            var last = result.Last();
            top.Should().Be(last);
            top.Should().Be("__A__");
        }
        
        [Fact]
        public void ShouldCreateDiamondMiddleLine_GivenDiamondMidpoint()
        {
            //Arrange
            var midpoint = 'D';

            //Act
            var result = _sut.Create(midpoint);

            //Assert
            var middle = result.Single(l => l.Contains("D"));
            middle.ToCharArray().Should().HaveCount(7);
            middle.Should().Be("D_____D");
        }
        
        [Fact]
        public void ShouldCreateDiamondLine_GivenDiamondMidpoint()
        {
            //Arrange
            var midpoint = 'D';

            //Act
            var result = _sut.Create(midpoint);

            //Assert
            var middle = result.First(l => l.Contains("C"));
            middle.ToCharArray().Should().HaveCount(7);
            middle.Should().Be("_C___C_");
        }
        
        [Fact]
        public void ShouldCreateDiamondWithCorrectSize_GivenDiamondMidpoint()
        {
            //Arrange
            var midpoint = 'D';

            //Act
            var result = _sut.Create(midpoint);

            //Assert
            result.Should().HaveCount(7);
        }
        
        [Fact]
        public void ShouldCreateDiamondWithCorrectLineSize_GivenDiamondMidpoint()
        {
            //Arrange
            var midpoint = 'D';

            //Act
            var result = _sut.Create(midpoint);

            //Assert
            result.Should().OnlyContain(l => l.ToCharArray().Length == 7);
        }
    }
}