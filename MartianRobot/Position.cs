﻿namespace MartianRobot
{
    public class Position(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Position ClonePosition() => new(X, Y);
    }
}
