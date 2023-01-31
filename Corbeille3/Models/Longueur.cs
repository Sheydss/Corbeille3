using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Models
{
    internal class Longueur
    {
        public uint x { get; }
        public uint y { get; }

        public Longueur(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }

        public Longueur() { }

        public static bool operator ==(Longueur left, Longueur right)
        {
            if(left.x == right.x && left.y == right.y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Longueur left, Longueur right) { return !(left == right); }

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
