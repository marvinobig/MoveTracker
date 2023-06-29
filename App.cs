using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveTracker
{
    internal class App
    {
        private readonly string _dbPath;
        private readonly int _seperator;
        public App(string dbPath, int seperator)
        {
            _dbPath = dbPath;
            _seperator = seperator;
        }

        public void DisplayIntro()
        {
            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("Welcome to Move Tracker");
            Console.WriteLine("Track how much you move throughout the day");

            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }
        }

        public void DisplayMenu() 
        {
            Console.Clear();

            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("MAIN MENU");
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("Type 0 to Close Application");
            Console.WriteLine("Type 1 to Insert a Record");
            Console.WriteLine("Type 2 to View All Records");
            Console.WriteLine("Type 3 to Update a Record");
            Console.WriteLine("Type 4 to Delete a Record");

            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("");
        }

        static void QuitApp() => Environment.Exit(0);
    }
}
