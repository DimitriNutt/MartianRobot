namespace MartianRobot
{
    public class Robot(Grid grid, int x, int y, char orientation)
    {
        private static readonly char[] Directions = { 'N', 'E', 'S', 'W' };
        public Grid Grid { get; } = grid;
        public Position Position { get; private set; } = new Position(x, y);
        public char Orientation { get; private set; } = orientation;
        public bool IsLost { get; private set; } = false;

        public void TurnLeft()
        {
            int index = Array.IndexOf(Directions, Orientation);
            index = index == 0 ? 3 : index - 1;
            Orientation = Directions[index];
        }

        public void TurnRight()
        {
            int index = Array.IndexOf(Directions, Orientation);
            index = index == 3 ? 0 : index + 1;
            Orientation = Directions[index];
        }

        public bool MoveForward()
        {
            var oldPosition = Position.ClonePosition();
            switch (Orientation)
            {
                case 'N':
                    Position.Y++;
                    break;
                case 'E':
                    Position.X++;
                    break;
                case 'S':
                    Position.Y--;
                    break;
                case 'W':
                    Position.X--;
                    break;
            }

            if (!Grid.IsPresent(Position))
            {
                Position = oldPosition;
                if (!Grid.IsScented(Position))
                {
                    Grid.LeaveScent(Position);
                    IsLost = true;
                    return false;
                }
            }

            return true;
        }

        public bool Move(char command)
        {
            switch (command)
            {
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'F':
                    return MoveForward();
            }

            return true;
        }

        public bool ProcessCommands(string commands)
        {
            foreach (var c in commands)
            {
                if (!Move(c)) return false;
            }

            return true;
        }

        public override string ToString()
        {
            var lostStatus = IsLost ? " LOST" : "";
            return $"{Position.X} {Position.Y} {Orientation} {lostStatus}";
        }
    }
}
