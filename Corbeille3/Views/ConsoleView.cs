using Corbeille3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbeille3.Views
{
    internal class ConsoleView
    {
        public ConsoleView() { }

        /// <summary>
        /// function to get a int from user
        /// </summary>
        /// <param name="message"></param>
        /// <param name="MaxRetry"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetInt(string message, int MaxRetry)
        {
            var i = 0;
            Console.WriteLine(message);
            while(i < MaxRetry)
            {
                var input = 0;
                if(int.TryParse(Console.ReadLine(), out input)) {
                    return input;
                }
                i++;
            }
            throw new Exception("Max retry reached");
        }

        /// <summary>
        /// function to get a string from user
        /// </summary>
        /// <param name="message"></param>
        /// <param name="MaxRetry"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetString(string message, int MaxRetry)
        {
            var i = 0;
            Console.WriteLine(message);
            while (i < MaxRetry)
            {
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                i++;
            }
            throw new Exception("Max retry reached");
        }

        /// <summary>
        /// function to write in console
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// function to display univers
        /// </summary>
        /// <param name="u"></param>
        public void DisplayUnivers(Univers u)
        {
            var buffer = "┌";
            for (int d = u.position.x; d < u.longueur.x -1; d++) { buffer += "───┬"; }
            buffer += "───┐";
            Console.WriteLine(buffer); 
            for(int i = u.position.y; i < u.longueur.y; i++)
            {
                buffer = "│";
                for(int j = u.position.x; j < u.longueur.x; j++)
                {
                    var element = u.GetElement(i, j);
                    if (element != null)
                    {
                        buffer += element.Symbole;
                        if (element.Symbole.Length == 1) buffer += "  ";
                        if (element.Symbole.Length == 2) buffer += " ";
                    }
                    else buffer += "   ";
                    buffer += "│";
                }
                Console.WriteLine(buffer);
                if (i < u.longueur.y -1)
                {
                    buffer = "├";
                    for (int d = u.position.x; d < u.longueur.x - 1; d++) { buffer += "───┼"; }
                    buffer += "───┤";
                    Console.WriteLine(buffer);
                }
            }
            buffer = "└";
            for (int d = u.position.x; d < u.longueur.x -1; d++) { buffer += "───┴"; }
            buffer += "───┘";
            Console.WriteLine(buffer);
        }
    }
}
