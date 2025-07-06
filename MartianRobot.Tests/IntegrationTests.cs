namespace MartianRobot.Tests
{
    public class MartianRobotRunnerTests
    {
        [Fact]
        public void Run_WithSampleInput_ShouldReturnExpectedOutput()
        {
            var input = @"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL";

            var result = MartianRobotRunner.Run(input);

            var expected = @"1 1 E
3 3 N LOST
2 3 S";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Run_WithSingleRobot_ShouldReturnCorrectOutput()
        {
            var input = @"3 3
1 1 N
F";

            var result = MartianRobotRunner.Run(input);

            Assert.Equal("1 2 N", result);
        }
    }
}
