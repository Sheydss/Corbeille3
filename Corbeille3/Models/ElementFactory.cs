using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Models
{
    internal class ElementFactory
    {
        private static ElementFactory? _instance;
        static readonly object instanceLock = new object();


        private ElementFactory() { }

        public static ElementFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new ElementFactory();
                    }
                }
                return _instance;
            }
        }

        public Atome? Create(string name, Position position)
        {
            switch(name)
            {
                case "Carbone":
                    return new Atome("Carbone", "C", 12.01074, position);
                case "Hydrogène":
                    return new Atome("Hydrogène", "H", 1.00794, position);
                case "Lithium":
                    return new Atome("Lithium", "Li", 6.941, position);
                case "Oxygène":
                    return new Atome("Oxygène", "O", 15.999, position);
                default: 
                    return null;
            }
        }

        public Atome? Create(string name, int x, int y)
        {
            Position position = new Position(x, y);
            switch (name)
            {
                case "Carbone":
                    return new Atome("Carbone", "C", 12.01074, position);
                case "Hydrogène":
                    return new Atome("Hydrogène", "H", 1.00794, position);
                case "Lithium":
                    return new Atome("Lithium", "Li", 6.941, position);
                case "Oxygène":
                    return new Atome("Oxygène", "O", 15.999, position);
                default:
                    return null;
            }
        }

        public Molécule? Create(string name, Position position, ICollection<IElement> Elements)
        {
            switch (name)
            {
                case "Eau":
                    return new Molécule("Eau", "H2O", 18.01528, position, Elements);
                default:
                    return null;
            }
        }

        public Molécule? Create(string name, int x, int y, ICollection<IElement> Elements)
        {
            Position position = new Position(x, y);
            switch (name)
            {
                case "Eau":
                    return new Molécule("Eau", "H2O", 18.01528, position, Elements);
                default:
                    return null;
            }
        }

    }
}
