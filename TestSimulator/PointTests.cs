using Simulator;
using Simulator.Maps;
namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinates()
    {
        int x = 5;
        int y = 10;
        var point = new Point(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-5, -10)]
    [InlineData(int.MaxValue, int.MinValue)]
    public void Constructor_ShouldInitializeCoordinates(int x, int y)
    {
        var point = new Point(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(2, 3, Direction.Up, 2, 4)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(7, 7, Direction.Down, 7, 6)]
    [InlineData(1, 1, Direction.Left, 0, 1)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(expectedX, nextPoint.X);
        Assert.Equal(expectedY, nextPoint.Y);
    }

    [Theory]
    [InlineData(7, 7, 7, 7, true)]
    [InlineData(1, 1, 2, 2, false)]
    [InlineData(0, 0, 0, 0, true)]
    [InlineData(5, 5, 5, 6, false)]
    [InlineData(-10, -10, -10, -10, true)]
    public void Equality_ShouldReturnCorrectComparison(int x1, int y1, int x2, int y2, bool expectedEqual)
    {
        var point1 = new Point(x1, y1);
        var point2 = new Point(x2, y2);
        if (expectedEqual)
        {
            Assert.Equal(point1, point2);
        }
        else
        {
            Assert.NotEqual(point1, point2);
        }
    }

    [Theory]
    [InlineData(2, 3, Direction.Up, 3, 4)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(7, 7, Direction.Down, 6, 6)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    public void NextDiagonal_ShouldReturnCorrectNextDiagonalPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(direction);
        Assert.Equal(expectedX, nextPoint.X);
        Assert.Equal(expectedY, nextPoint.Y);
    }
}
