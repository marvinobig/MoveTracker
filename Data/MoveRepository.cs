using MoveTracker.Models;
using SQLite;


namespace MoveTracker.Data
{
    internal class MoveRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection? _dbConn;

        public MoveRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init(_dbPath);
        }

        private void Init(string dbPath)
        {
            try
            {
                string dbCommands = @"CREATE TABLE IF NOT EXISTS move(
                                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                        numOfMoves INTEGER NOT NULL, 
                                        timeRecorded TEXT DEFAULT CURRENT_DATE
                                    );";

                _dbConn = new SQLiteConnection(dbPath);
                _dbConn.CreateCommand(dbCommands).ExecuteNonQuery();
                _dbConn.Close();

                Console.WriteLine("Move Table Created");
            }
            catch (SQLiteException err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public List<Move> GetAllMove() 
        {
            try
            {
                string dbCommands = @"SELECT * FROM move;";
                _dbConn = new SQLiteConnection(_dbPath);

                List<Move> listOfMoves = _dbConn.CreateCommand(dbCommands).ExecuteQuery<Move>();
                _dbConn.Close();

                return listOfMoves;
            }
            catch (SQLiteException err) 
            { 
                Console.WriteLine(err.Message);
            }

            return new List<Move>();
        }

        public void AddMove(Move move)
        {
            _dbConn = new SQLiteConnection(_dbPath);
            _dbConn.Insert(move);
        }

        public void DeleteMove(int id)
        {
            _dbConn = new SQLiteConnection(_dbPath);
            _dbConn.Delete(new Move { Id = id });
        }
    }
}
