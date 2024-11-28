using CombinationGenerator;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using WordCombiner;

namespace UnitTests
{
    public class CombinationGeneratorTests
    {
        [Fact]
        public async void GenerateCombinations_ShouldNotIncludeDuplicates()

        {
            //Arrange
            var lines = new List<string>()
            {
                "ab",
                "c",
                "d"
            };

            var combinationLength = 3;

            //Act
            var result = CombinationGenerator.GenerateCombinations(lines, combinationLength);

            //Assert
            Assert.False(result.GroupBy(c => c).Any(c => c.Count() > 1));
        }

        [Fact]
        public async void GenerateCombinations_CombinationsShouldHaveCorrectLength()

        {
            //Arrange
            var lines = new List<string>()
            {
                "go",
                "c",
                "di",
                "corn",
                "bo",
                "a"
            };

            var combinationLength = 4;

            //Act
            var result = CombinationGenerator.GenerateCombinations(lines, combinationLength);

            //Assert
            Assert.True(result.All(c => c.Replace("+", "").Length == combinationLength));
        }
    }
}