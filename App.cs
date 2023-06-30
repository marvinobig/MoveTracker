using MoveTracker.Data;


namespace MoveTracker
{
    internal class App
    {
        private readonly int _seperator;
        public readonly MoveRepository Repository;
        public readonly MoveTrackerActions _actions;

        public App(string dbPath, int seperator)
        {
            _seperator = seperator;
            Repository = new MoveRepository(dbPath);
            _actions = new MoveTrackerActions(dbPath);
        }

        public void DisplayIntro()
        {
            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("");
            Console.WriteLine("Welcome to Move Tracker", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
            Console.ResetColor();
            Console.WriteLine("Track how much you move throughout the day");

            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Press any key to continue ");
            Console.ReadLine();
            Console.WriteLine("");
        }

        public void DisplayMenu(string err = "") 
        {
            Console.ResetColor();
            Console.Clear();

            for (int i = 0; i < _seperator; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("");
            Console.WriteLine("MAIN MENU", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
            Console.ResetColor();
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
            if (err != "") Console.WriteLine(err.ToUpper(), Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Black);
            Console.WriteLine("");
            Console.ResetColor();
            
            Console.Write("Your Choice: ");
            bool userChoice = int.TryParse(Console.ReadLine(), out int userChoiceNum);

            if (userChoice && (userChoiceNum >= 0 && userChoiceNum <= 4))
            {
                Console.Clear();
                _actions.DecisionHandler(userChoiceNum);
            } 
            else
            {
                DisplayMenu("Please type a number from one of the options");
            }
        }

        public static void QuitApp() => Environment.Exit(0);
    }
}
