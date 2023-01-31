using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Corbeille3.Models
{
    internal class Univers
    {
        public Position position { get; } = new Position();
        public Longueur longueur { get; } = new Longueur();
        public List<IElement> elements { get; } = new List<IElement>();
        public ElementFactory factory { get; } = ElementFactory.Instance;
        /// <summary>
        /// ctor univers from position and longueur
        /// </summary>
        /// <param name="position"></param>
        /// <param name="longueur"></param>
        public Univers(Position position, Longueur longueur)
        {
            this.longueur = longueur;
            this.position = position;
        }
        /// <summary>
        /// ctor univers with coordinate PosX and PosY, length LenX and LenY
        /// </summary>
        /// <param name="PosX"></param>
        /// <param name="PosY"></param>
        /// <param name="LenX"></param>
        /// <param name="LenY"></param>
        public Univers(int PosX, int PosY, uint LenX, uint LenY)
        {
            this.position = new Position(PosX, PosY);
            this.longueur = new Longueur(LenX, LenY);
        }
        /// <summary>
        /// ctor univers with origin 0 0 and length 0 0
        /// </summary>
        public Univers() { }
        /// <summary>
        /// Add an IElement to univers
        /// </summary>
        /// <param name="Element"></param>
        /// <returns></returns>
        public bool AddElement(IElement Element) 
        {
            try
            {
                if (Element.position.x < position.x || Element.position.y < position.y || Element.position.x > (longueur.x - 1 + position.x) || Element.position.y > (longueur.y - 1 + position.y)) return false;
                foreach(var element in elements)
                {
                    if(Element.position == element.position)
                    {
                        return false;
                    }
                }
                elements.Add(Element);
                OnAddElement();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// create an IElement (Atome) named Name, located at position and add it to the univers
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool AddElement(string Name, Position position)
        {
            try
            {
                var el = factory.Create(Name, position);
                if(el != null)
                {
                    if (el.position.x < position.x || el.position.y < position.y || el.position.x > (longueur.x - 1 + position.x) || el.position.y > (longueur.y - 1 + position.y)) return false;
                    foreach (var element in elements)
                    {
                        if (el.position == element.position)
                        {
                            return false;
                        }
                    }
                    elements.Add(el);
                    OnAddElement();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// create an IElement (Atome) named Name, located at x y and add it to the univers
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool AddElement(string Name, int x, int y)
        {
            try
            {
                var position = new Position(x, y);
                var el = factory.Create(Name, position);
                if (el != null)
                {
                    if (el.position.x < position.x || el.position.y < position.y || el.position.x > (longueur.x - 1 + position.x) || el.position.y > (longueur.y - 1 + position.y)) return false;
                    foreach (var element in elements)
                    {
                        if (el.position == element.position)
                        {
                            return false;
                        }
                    }
                    elements.Add(el);
                    OnAddElement();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Create an IElement (molécule) named Name, located at x y, composed of Elements and add it to the univers
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Elements"></param>
        /// <returns></returns>
        public bool AddElement(string Name, int x, int y, ICollection<IElement> Elements)
        {
            try
            {
                var position = new Position(x, y);
                var el = factory.Create(Name, position, Elements);
                if (el != null)
                {
                    if (el.position.x < position.x || el.position.y < position.y || el.position.x > (longueur.x - 1 + position.x) || el.position.y > (longueur.y - 1 + position.y)) return false;
                    foreach (var element in elements)
                    {
                        if (el.position == element.position)
                        {
                            return false;
                        }
                    }
                    elements.Add(el);
                    OnAddElement();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Create an IElement (molécule) named Name, located at position, composed of Elements and add it to the univers
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="position"></param>
        /// <param name="elements"></param>
        /// <returns></returns>
        public bool AddElement(string Name, Position position, ICollection<IElement> elements)
        {
            try
            {
                var el = factory.Create(Name, position, elements);
                if (el != null)
                {
                    if (el.position.x < position.x || el.position.y < position.y || el.position.x > (longueur.x - 1 + position.x) || el.position.y > (longueur.y - 1 + position.y)) return false;
                    foreach (var element in elements)
                    {
                        if (el.position == element.position)
                        {
                            return false;
                        }
                    }
                    elements.Add(el);
                    OnAddElement();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// remove element from univers
        /// </summary>
        /// <param name="Element"></param>
        /// <returns></returns>
        public bool RemoveElement(IElement Element)
        {
            try
            {
                if (elements.Remove(Element)) {
                    OnRemoveElement();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// remove IElement at x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool RemoveElement(int x, int y)
        {
            var el = GetElement(x, y);
            if (el != null)
            {
                if (elements.Remove(el))
                {
                    OnRemoveElement();
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// remove IElement at position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool RemoveElement(Position position)
        {
            var el = GetElement(position);
            if (el != null)
            {
                if (elements.Remove(el))
                {
                    OnRemoveElement();
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// Get IElement at position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IElement? GetElement(Position position)
        {
            foreach(var element in elements)
            {
                if(element.position == position) return element;
            }
            return null;
        }
        /// <summary>
        /// Get Element at x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public IElement? GetElement(int x, int y)
        {
            var position = new Position(x, y);
            foreach (var element in elements)
            {
                if (element.position == position) return element;
            }
            return null;
        }
        /// <summary>
        /// Move IElement from xOrigin yOrigin to xTarget yTarget
        /// </summary>
        /// <param name="xOrigin"></param>
        /// <param name="yOrigin"></param>
        /// <param name="xTarget"></param>
        /// <param name="yTarget"></param>
        /// <returns></returns>
        public bool MoveElement(int xOrigin, int yOrigin, int xTarget, int yTarget)
        {
            var el = GetElement(xOrigin, yOrigin);
            if (el != null) {
                el.Move(xTarget, yTarget);
                OnMoveElement();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Move IElement from positionOrigin to positionTarget
        /// </summary>
        /// <param name="positionOrigin"></param>
        /// <param name="positionTarget"></param>
        /// <returns></returns>
        public bool MoveElement(Position positionOrigin, Position positionTarget)
        {
            var el = GetElement(positionOrigin);
            if(el != null)
            {
                el.Move(positionTarget);
                OnMoveElement();
                return true;
            }
            return false;
        }

        public void OnAddElement()
        {
            foreach(var element in elements)
            {
                element.Notify("Adding Element");
            }
        }

        public void OnRemoveElement()
        {
            foreach(var element in elements)
            {
                element.Notify("Removing Element");
            }
        }

        public void OnMoveElement()
        {
            foreach(var element in elements)
            {
                element.Notify("Moving Element");
            }
        }

    }
}
