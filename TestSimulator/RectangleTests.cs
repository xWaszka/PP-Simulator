using Simulator;
using Simulator.Maps;
namespace TestSimulator;


public class RectangleTests
{
    [Theory]
    [InlineData(0, 0, 2, 2)]
    [InlineData(-1, -1, 1, 1)]
    [InlineData(-5, -10, 5, 10)]
    public void Constructor_ShouldCreateRectangle(int x1, int y1, int x2, int y2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(x1, rectangle.X1);
        Assert.Equal(y1, rectangle.Y1);
        Assert.Equal(x2, rectangle.X2);
        Assert.Equal(y2, rectangle.Y2);
    }

    [Theory]
    [InlineData(2, 2, 2, 4)]
    [InlineData(1, 3, 4, 3)]
    public void Constructor_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(5, 5, 2, 2)]
    [InlineData(3, 4, 1, 2)]
    public void Constructor_ShouldNormalizeCoordinates(int x1, int y1, int x2, int y2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.True(rectangle.X1 < rectangle.X2);
        Assert.True(rectangle.Y1 < rectangle.Y2);
    }

    [Fact]
    public void Constructor_WithPoints_ShouldCreateRectangle()
    {
        var point1 = new Point(1, 1);
        var point2 = new Point(3, 4);
        var rectangle = new Rectangle(point1, point2);

        Assert.Equal(1, rectangle.X1);
        Assert.Equal(1, rectangle.Y1);
        Assert.Equal(3, rectangle.X2);
        Assert.Equal(4, rectangle.Y2);
    }

    [Theory]
    [InlineData(0, 0, 2, 2, 1, 1, true)]
    [InlineData(0, 0, 2, 2, 3, 3, false)]
    [InlineData(-2, -2, 2, 2, 0, 0, true)]
    [InlineData(-2, -2, 2, 2, -3, -3, false)]
    [InlineData(0, 0, 2, 2, 0, 0, true)]
    [InlineData(0, 0, 2, 2, 2, 2, true)]
    public void Contains_ShouldReturnCorrectResult(int rectX1, int rectY1, int rectX2, int rectY2,
        int pointX, int pointY, bool expectedResult)
    {
        var rectangle = new Rectangle(rectX1, rectY1, rectX2, rectY2);
        var point = new Point(pointX, pointY);

        Assert.Equal(expectedResult, rectangle.Contains(point));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var rectangle = new Rectangle(1, 2, 3, 4);
        Assert.Equal("(1, 2):(3, 4)", rectangle.ToString());
    }
}
