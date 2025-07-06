namespace MartianRobot.Tests
{
    public class GridTests
    {
        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(0, 0, true)]
        [InlineData(5, 3, true)]
        [InlineData(-1, 0, false)]
        [InlineData(0, -1, false)]
        [InlineData(6, 3, false)]
        [InlineData(5, 4, false)]
        public void IsValidPosition_ShouldValidateBoundaries(int x, int y, bool expected)
        {
            var grid = new Grid(5, 3);
            var position = new Position(x, y);
            
            var result = grid.IsValidPosition(position);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void LeaveScent_ShouldMakePositionScented()
        {
            var grid = new Grid(5, 3);
            var position = new Position(2, 1);
            
            grid.LeaveScent(position);
            
            Assert.True(grid.HasScent(position));
        }
    }
}
