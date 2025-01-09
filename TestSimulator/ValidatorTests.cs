using Simulator;
namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 1, 10, 5)]
        [InlineData(0, 1, 10, 1)]
        [InlineData(15, 1, 10, 10)]
        [InlineData(4, 3, 7, 4)]
        [InlineData(5, 5, 5, 5)]
        public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
        {
            int result = Validator.Limiter(value, min, max);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hello World", 5, 10, '#', "Hello worl")]
        [InlineData("   ", 5, 10, '#', "#####")]
        [InlineData(null, 5, 10, '#', "#####")]
        [InlineData("abc", 5, 10, '#', "Abc##")]
        [InlineData("SuperASDASDASDASD", 5, 10, '#', "Superasdas")]
        [InlineData("short", 5, 5, '#', "Short")]
        [InlineData("capitalized", 3, 10, '#', "Capitalize")]
        public void Shortener_ShouldReturnCorrectShortenedString(string value, int min, int max, char placeholder, string expected)
        {
            string result = Validator.Shortener(value, min, max, placeholder);
            Assert.Equal(expected, result);
        }
    }
}


