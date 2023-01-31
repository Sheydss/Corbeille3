using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Models
{
    internal class Atome : IElement
    {
        public string Name { get; } = "Carbone";
        public string Symbole { get; } = "C";
        public double Masse { get; } = 12.01074;
        public Position position { get; set; } = new Position();

        public Atome(Position position)
        {
            this.position = position;
        }

        /// <summary>
        /// ctor a carbon at 0 0
        /// </summary>
        public Atome() { }

        /// <summary>
        /// ctor a carbon at x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Atome(int x, int y)
        {
            this.position = new Position(x, y);
        }
        /// <summary>
        /// ctor a Atome at 0 0
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Symbole"></param>
        /// <param name="Masse"></param>
        public Atome(string Name, string Symbole, double Masse)
        {
            this.Name = Name;
            this.Symbole = Symbole;
            this.Masse= Masse;
        }
        /// <summary>
        /// ctor a Atome at x y
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Symbole"></param>
        /// <param name="Masse"></param>
        /// <param name="position"></param>
        public Atome(string Name, string Symbole, double Masse, Position position)
        {
            this.Name = Name;
            this.Symbole = Symbole;
            this.Masse = Masse;
            this.position = position;
        }
        /// <summary>
        /// move atome at position
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
        /// move atome at x y
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
        /// event
        /// </summary>
        /// <param name="msg"></param>
        public void Notify(string msg)
        {
            //Console.WriteLine(msg);
        }
    }
}
