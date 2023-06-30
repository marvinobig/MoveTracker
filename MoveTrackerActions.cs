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

        private void TrackNewMove()
        {
            Console.Write("How much have you moved today? ");
            bool userTrack = int.TryParse(Console.ReadLine(), out int movesAdd);

            if (userTrack)
            {
                _repository.AddMove(movesAdd);
                Console.WriteLine("Number of Moves Tracked");
            }
            else
            {
                Console.WriteLine("Number of Moves Not Tracked");
            }
        }

        private void DisplayListOfMoves()
        {
            Console.Clear();
            foreach (Move move in _repository.GetAllMove())
            {
                Console.WriteLine($"ID: {move.Id}");
                Console.WriteLine($"Moves: {move.numOfMoves}");
                Console.WriteLine($"Date Recorded: {move.timeRecorded}");
                Console.WriteLine("");
            }
        }

        private void UpdateListOfMoves()
        {
            Console.Clear();
            Console.Write("What move do you want to update? ");
            bool moveUpdate = int.TryParse(Console.ReadLine(), out int moveToUpdate);

            if (moveUpdate)
            {
                Console.WriteLine("What is the new value? ");
                bool moveId = int.TryParse(Console.ReadLine(), out int newMoveValue);

                if (moveId) _repository.UpdateMove(moveToUpdate, newMoveValue);
            }
            else
            {
                Console.WriteLine("Move Not Updated");
            }
        }

        private void DeleteMoveById()
        {
            Console.Write("What move do you want to delete? ");
            bool userDelete = int.TryParse(Console.ReadLine(), out int movesDelete);

            if (userDelete)
            {
                _repository.DeleteMove(movesDelete);
                Console.WriteLine("Chosen Move Deleted");
            }
            else
            {
                Console.WriteLine("Move Not Deleted");
            }

        }
    }
}
