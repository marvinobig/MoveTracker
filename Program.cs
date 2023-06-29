using MoveTracker.Data;
using MoveTracker.Models;

Console.WriteLine("Move Tracker");
string dbPath = Path.Combine(Environment.CurrentDirectory, "MoveDB.sql");

Console.WriteLine(dbPath);

Console.Write("How much have you moved today? ");
bool userTrack = int.TryParse(Console.ReadLine(), out int movesAdd);

if (userTrack)
{
    new MoveRepository(dbPath).AddMove(movesAdd);
    Console.WriteLine("Number of Moves Tracked");
}
else
{
    Console.WriteLine("Number of Moves Not Tracked");
}


Console.Clear();
foreach (Move move in new MoveRepository(dbPath).GetAllMove())
{
    Console.WriteLine($"ID: {move.Id}");
    Console.WriteLine($"Moves: {move.numOfMoves}");
    Console.WriteLine($"Date Recorded: {move.timeRecorded}");
    Console.WriteLine("");
}
Console.Write("What move do you want to delete? ");
bool userDelete = int.TryParse(Console.ReadLine(), out int movesDelete);

if (userDelete)
{
    new MoveRepository(dbPath).DeleteMove(movesDelete);
    Console.WriteLine("Chosen Move Deleted");
}
else
{
    Console.WriteLine("Move Not Deleted");
}


Console.Clear();
Console.Write("What move do you want to update? ");
bool moveUpdate = int.TryParse(Console.ReadLine(), out int moveToUpdate);

if (moveUpdate)
{
    Console.WriteLine("What is the new value? ");
    bool moveId = int.TryParse(Console.ReadLine(),out int newMoveValue);

    if (moveId) new MoveRepository(dbPath).UpdateMove(moveToUpdate, newMoveValue);
}
else
{
    Console.WriteLine("Move Not Updated");
}
