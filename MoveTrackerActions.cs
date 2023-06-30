using MoveTracker.Data;
using MoveTracker.Models;

namespace MoveTracker
{
    internal class MoveTrackerActions
    {
        private readonly MoveRepository _repository;

        public MoveTrackerActions(string dbPath) 
        { 
            _repository = new MoveRepository(dbPath);
        }

        public void DecisionHandler(int userChoiceNum)
        {
            switch (userChoiceNum)
            {
                case 0:
                    App.QuitApp();
                    break;
                case 1:
                    TrackNewMove();
                    break;
                case 2:
                    DisplayListOfMoves();
                    break;
                case 3:
                    UpdateListOfMoves();
                    break;
                case 4:
                    DeleteMoveById();
                    break;
            }
        }

        private void TrackNewMove(string err = "")
        {
            Console.Clear();

            if (err != "") Console.WriteLine(err.ToUpper(), Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Black);
            Console.ResetColor();
            Console.WriteLine("");

            Console.Write("How much have you moved today? ");
            bool userTrack = int.TryParse(Console.ReadLine(), out int movesNum);

            if (userTrack)
            {
                _repository.AddMove(movesNum);
                Console.WriteLine("Number of Moves Tracked", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
                Console.ResetColor();
            }
            else
            {
                TrackNewMove("moves not tracked as you need to enter a valid number");
            }
        }

        private void DisplayListOfMoves()
        {
            Console.Clear();
            Console.WriteLine("All Tracked Moves:".ToUpper(), Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
            Console.ResetColor(); 
            Console.WriteLine("");

            foreach (Move move in _repository.GetAllMove())
            {
                Console.WriteLine($"ID: {move.Id}");
                Console.WriteLine($"Moves: {move.numOfMoves}");
                Console.WriteLine($"Date Recorded: {move.timeRecorded}");
                Console.WriteLine("");
            }
        }

        private void UpdateListOfMoves(string err = "")
        {
            Console.Clear();

            if (err != "") Console.WriteLine(err.ToUpper(), Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Black);
            Console.WriteLine("");
            Console.ResetColor();

            Console.Write("What move do you want to update? ", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
            Console.ResetColor();
            bool moveUpdate = int.TryParse(Console.ReadLine(), out int moveToUpdate);

            if (moveUpdate)
            {
                Console.WriteLine("What is the new value? ", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
                Console.ResetColor();
                bool moveId = int.TryParse(Console.ReadLine(), out int newMoveValue);

                if (moveId) _repository.UpdateMove(moveToUpdate, newMoveValue);
            }
            else
            {
                UpdateListOfMoves("move not updated as you need to enter a valid id");
            }
        }

        private void DeleteMoveById(string err = "")
        {
            Console.Clear();

            if (err != "") Console.WriteLine(err.ToUpper(), Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Black);
            Console.WriteLine("");
            Console.ResetColor();

            Console.Write("What move do you want to delete? ", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
            Console.ResetColor();
            bool userDelete = int.TryParse(Console.ReadLine(), out int movesDeleteNum);

            if (userDelete)
            {
                _repository.DeleteMove(movesDeleteNum);
                Console.WriteLine("Chosen Move Deleted", Console.BackgroundColor = ConsoleColor.Green, Console.ForegroundColor = ConsoleColor.Black);
                Console.ResetColor();
            }
            else
            {
                DeleteMoveById("move not deleted as you need to enter a valid id");
            }

        }
    }
}
