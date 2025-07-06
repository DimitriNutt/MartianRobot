namespace MartianRobot
{
    using System.Text;

    public class MartianRobotRunner
    {
        public static string Run(string instructions)
        {
            var lines = instructions.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            var gridParams = lines[index++].Split(' ');
            var grid = new Grid(int.Parse(gridParams[0]), int.Parse(gridParams[1]));
            var result = new StringBuilder();

            while (index < lines.Length)
            {
                var robotParams = lines[index++].Split(' ');
                if (robotParams.Length < 3) continue;
                var robot = new Robot(
                    grid,
                    int.Parse(robotParams[0]),
                    int.Parse(robotParams[1]),
                    robotParams[2][0]
                );

                if (index >= lines.Length) break;
                var commands = lines[index++];
                robot.ProcessCommands(commands);
                result.AppendLine(robot.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
