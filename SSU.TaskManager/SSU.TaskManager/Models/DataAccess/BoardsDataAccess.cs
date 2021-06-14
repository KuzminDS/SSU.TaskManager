using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SSU.TaskManager.Models.DataAccessInterface;
using SSU.TaskManager.Entities;

namespace SSU.TaskManager.Models
{
    public class BoardsDataAccess : IBoardsDataAccess
    {
        private SQLiteConnection _database;
        private static object _collisionLock = new object();
        public ObservableCollection<Board> Boards { get; set; }

        public BoardsDataAccess()
        {
            _database =
            DependencyService.Get<IDatabaseConnection>().
            DbConnection();
            _database.CreateTable<Board>();

            Boards = new ObservableCollection<Board>(_database.Table<Board>());

            if (!_database.Table<Board>().Any())
            {
                AddNewCustomer();
            }



        }

        public void AddNewCustomer()
        {
            SaveBoard(new Board() { Title = "TODO" });
            SaveBoard(new Board() { Title = "INPR" });
            SaveBoard(new Board() { Title = "DONE" });
        }


        public IEnumerable<Board> GetAll()
        {
            lock (_collisionLock)
            {
                return _database.
                  Query<Board>
                  ("SELECT * FROM Boards").
                  AsEnumerable();
            }
        }

        public void SaveBoard(Board boardInstance)
        {
            lock (_collisionLock)
            {
                if (boardInstance.Id != 0)
                {
                    _database.Update(boardInstance);
                }
                else
                {
                    _database.Insert(boardInstance);
                }
            }
        }

        public int DeleteBoard(Board boardInstance)
        {
            var id = boardInstance.Id;
            if (id != 0)
            {
                lock (_collisionLock)
                {
                    _database.Delete<Board>(id);
                }
            }
            this.Boards.Remove(boardInstance);
            return id;
        }

        public Board GetBoardById(int id)
        {
            lock (_collisionLock)
            {
                return _database.Table<Board>().FirstOrDefault(board => board.Id == id);
            }
        }
    }
}
