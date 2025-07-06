namespace MartianRobot
{
    public class Grid(int maxXCoordinate, int maxYCoordinate)
    {
        public int MaxXCoordinate { get; } = maxXCoordinate > 50 ? 50 : maxXCoordinate;
        public int MaxYCoordinate { get; } = maxYCoordinate > 50 ? 50 : maxYCoordinate;
        private HashSet<int> Scents { get; } = [];

        public void LeaveScent(Position position)
        {
            Scents.Add(position.Y * MaxXCoordinate + position.X);
        }

        public bool HasScent(Position position)
        {
            return Scents.Contains(position.Y * MaxXCoordinate + position.X);
        }

        public bool IsValidPosition(Position position)
        {
            return !(position.X < 0 || position.Y < 0 || position.X > MaxXCoordinate || position.Y > MaxYCoordinate);
        }
    }
}
