using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_ShouldInitializeSize(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidSize(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }
    [Theory]
    [InlineData(5, 0, 0, true)]
    [InlineData(5, 4, 4, true)]
    [InlineData(5, 5, 5, false)]
    [InlineData(10, 9, 9, true)]
    [InlineData(10, 10, 10, false)]
    public void Exist_ShouldReturnCorrectResult(int size, int pointX, int pointY, bool expectedExistence)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(pointX, pointY);
        Assert.Equal(expectedExistence, map.Exist(point));
    }

    [Theory]
    [InlineData(5, 0, 0, Direction.Up, 0, 1)]
    [InlineData(5, 4, 4, Direction.Left, 3, 4)]
    [InlineData(5, 4, 4, Direction.Right, 4, 4)]
    [InlineData(5, 0, 0, Direction.Down, 0, 0)]
    [InlineData(5, 0, 0, Direction.Left, 0, 0)]
    [InlineData(5, 4, 0, Direction.Right, 4, 0)]
    [InlineData(5, 0, 4, Direction.Up, 0, 4)]
    public void Next_ShouldReturnCorrectNextPoint(int size, int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(size);
        var startPoint = new Point(startX, startY);
        var nextPoint = map.Next(startPoint, direction);
        Assert.Equal(expectedX, nextPoint.X);
        Assert.Equal(expectedY, nextPoint.Y);
    }

    [Theory]
    [InlineData(5, 0, 0, Direction.Up, 1, 1)]
    [InlineData(5, 4, 4, Direction.Left, 4, 4)]
    [InlineData(5, 0, 0, Direction.Down, 0, 0)]
    [InlineData(5, 4, 0, Direction.Right, 4, 0)]
    [InlineData(5, 0, 4, Direction.Left, 0, 4)]
    [InlineData(5, 2, 2, Direction.Up, 3, 3)]
    [InlineData(5, 2, 2, Direction.Down, 1, 1)]
    [InlineData(5, 2, 2, Direction.Left, 1, 3)]
    [InlineData(5, 2, 2, Direction.Right, 3, 1)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int size, int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(size);
        var startPoint = new Point(startX, startY);
        var nextPoint = map.NextDiagonal(startPoint, direction);
        Assert.Equal(expectedX, nextPoint.X);
        Assert.Equal(expectedY, nextPoint.Y);
    }

}
