using System;
using System.Collections.Generic;
using System.Text;

namespace PrincessGame.DLL.PlayingField
{
    public struct Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() => $"({X}; {Y})";

        public static bool operator ==(Position pos1, Position pos2) =>
            pos1.X == pos2.X && pos1.Y == pos2.Y;

        public static bool operator !=(Position pos1, Position pos2) =>
            !(pos1 == pos2);

        public static implicit operator Position(ValueTuple<int, int> tuple) =>
            new Position(tuple.Item1, tuple.Item2);
    }
}
