using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Models
{
    internal class Position
    {
        public int x { get; } = 0;
        public int y { get; } = 0;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position() { }

        public static bool operator ==(Position left, Position right)
        {
            if(left.x == right.x && left.y == right.y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
