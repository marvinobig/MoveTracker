using MoveTracker;

Console.WriteLine("Move Tracker");
string dbPath = Path.Combine(Environment.CurrentDirectory, "MoveDB.sql");

App MoveApp = new(dbPath, 50);
MoveApp.DisplayIntro();
MoveApp.DisplayMenu();
