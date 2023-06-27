using MoveTracker.Data;

Console.WriteLine("Move Tracker");
string dbPath = Path.Combine(Environment.CurrentDirectory, "MoveDB.sql");

Console.WriteLine(dbPath);

new MoveRepository(dbPath);

