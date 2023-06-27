using SQLite;

namespace MoveTracker.Models
{
    [Table("move")]
    public class Move
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public int numOfMoves { get; set; }
        public DateTime timeRecorded { get; set; }
    }
}
