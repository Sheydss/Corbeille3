using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Models
{
    internal interface IElement
    {
        public string Name { get; }
        public string Symbole { get; }
        public double Masse { get; }
        public Position position { get; set; }
        public bool Move(Position position);
        public bool Move(int x, int y);
        public void Notify(string msg);
    }
}
