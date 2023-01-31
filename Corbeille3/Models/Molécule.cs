using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Models
{
    internal class Molécule : IElement
    {
        public string Name { get; } = "Oxyde de dihydrogène";
        public string Symbole { get; } = "H2O";
        public double Masse { get; } = 18.01528;
        public Position position { get; set; } = new Position();
        public ICollection<IElement> Elements { get; } = 
            new Atome[3]{
                new Atome("Hydrogène", "H", 1.00794, new Position()), 
                new Atome("Oxygène", "O", 15.999,  new Position()),
                new Atome("Hydrogène", "H", 1.00794, new Position())
            };
        /// <summary>
        /// ctor H2O at 0 0
        /// </summary>
        public Molécule() { }
        /// <summary>
        /// ctor H2O at position
        /// </summary>
        /// <param name="position"></param>
        public Molécule(Position position) { this.position = position; }
        /// <summary>
        /// ctor H2O at x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Molécule(int x, int y) { this.position = new Position(x, y); }
        /// <summary>
        /// ctor a Molécule at position
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Symbole"></param>
        /// <param name="Masse"></param>
        /// <param name="position"></param>
        /// <param name="elements"></param>
        public Molécule(string Name, string Symbole, double Masse, Position position, ICollection<IElement> elements) 
        { 
            this.Name= Name;
            this.Symbole= Symbole;
            this.Masse = Masse;
            this.position = position;
            this.Elements= elements;
        }
        /// <summary>
        /// ctor Molécule composed at x y
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Symbole"></param>
        /// <param name="Masse"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="elements"></param>
        public Molécule(string Name, string Symbole, double Masse, int x, int y, ICollection<IElement> elements)
        {
            this.Name = Name;
            this.Symbole = Symbole;
            this.Masse = Masse;
            this.position = new Position(x, y);
            this.Elements = elements;
        }
        /// <summary>
        /// Move molécule at position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool Move(Position position)
        {
            try
            {
                this.position = position;
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// move molécule at x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Move(int x, int y)
        {
            try
            {
                var position = new Position(x, y);
                this.position = position;
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Event
        /// </summary>
        /// <param name="msg"></param>
        public void Notify(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
