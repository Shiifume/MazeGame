using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class MazePosition : IComparable<MazePosition>
    {
        public int Line { private init; get; }

        public int Col { private init; get; }

        public MazePosition(int line, int col)
        {
            Line = line;
            Col = col;
        }

        /*
         * COMPARISON OVERRIDES
         */

        public int CompareTo(MazePosition? other)
        {
            return (other is null ? 1 : (this.Line != other.Line ? this.Line.CompareTo(other.Line) : this.Col.CompareTo(other.Col)));
        }

        public override bool Equals(object? obj)
        {
            return (obj is MazePosition other && this.Line == other.Line && this.Col == this.Col);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Line, Col);
        }

        public static bool operator ==(MazePosition? left, MazePosition? right)
        {
            if (left is null)
                return right is null;

            return left.Line == right.Line && left.Col == right.Col;
        }

        public static bool operator !=(MazePosition? left, MazePosition? right)
        {
            return !(left == right);
        }

        public static bool operator >(MazePosition? left, MazePosition? right)
        {
            if (left is null)
                return right is not null;
            
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(MazePosition? left, MazePosition? right)
        {
            if (left is null)
                return false;

            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(MazePosition? left, MazePosition? right)
        {
            return left == right || left < right;
        }

        public static bool operator >=(MazePosition? left, MazePosition? right)
        {
            return left == right || left > right;
        }
    }
}
