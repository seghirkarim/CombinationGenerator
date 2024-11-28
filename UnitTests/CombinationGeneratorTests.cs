
using CombinationGenerator;

namespace UnitTests
{
    public class CombinationGeneratorTests
    {
        [Fact]
        public void GenerateCombinations_ShouldNotIncludeDuplicates()

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
            var result = WordCombiner.GenerateCombinations(lines, combinationLength);

            //Assert
            Assert.DoesNotContain(result.GroupBy(c => c), c => c.Count() > 1);
        }

        [Fact]
        public void GenerateCombinations_CombinationsShouldHaveCorrectLength()

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
            var result = WordCombiner.GenerateCombinations(lines, combinationLength);

            //Assert
            Assert.True(result.All(c => c.Replace("+", "").Length == combinationLength));
        }
    }
}