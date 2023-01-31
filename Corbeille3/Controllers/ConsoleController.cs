using Corbeille3.Models;
using Corbeille3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Controllers
{
    internal class ConsoleController
    {
        private ConsoleView consoleView = new ConsoleView();

        public ConsoleController() {
            var univers = new Univers(new Position(), new Longueur(5, 5));
            univers.AddElement("Carbone", 0, 0);
            univers.AddElement("Hydrogène", 4, 4);
            univers.AddElement("Lithium", 1, 3);
            univers.RemoveElement(1, 3);
            univers.AddElement("Lithium", 1, 4);
            univers.MoveElement(1, 4, 2, 4);

            univers.AddElement("Oxygène", 2, 1);
            univers.AddElement("Hydrogène", 2, 2);
            univers.AddElement("Hydrogène", 2, 3);
            univers.AddElement("Eau", 3, 2, new IElement[3] { univers.GetElement(2, 1), univers.GetElement(2, 2), univers.GetElement(2, 3) });
            consoleView.DisplayUnivers(univers);
        }


    }
}
