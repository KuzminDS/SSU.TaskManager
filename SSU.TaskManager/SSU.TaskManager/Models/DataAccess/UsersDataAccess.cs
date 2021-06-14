using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SSU.TaskManager.Models.DataAccessInterface;
using SSU.TaskManager.Entities;

namespace SSU.TaskManager.Models
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private SQLiteConnection _database;
        private static object _collisionLock = new object();
        public ObservableCollection<User> Users { get; set; }

        public UsersDataAccess()
        {
            _database =
            DependencyService.Get<IDatabaseConnection>().
            DbConnection();
            _database.CreateTable<User>();

            Users = new ObservableCollection<User>(_database.Table<User>());

        }

        public IEnumerable<User> GetAll()
        {
            lock (_collisionLock)
            {
                return _database.
                  Query<User>
                  ("SELECT * FROM Users").
                  AsEnumerable();
            }
        }

        public void SaveUser(User userInstance)
        {
            lock(_collisionLock)
            {
                if (userInstance.Id != 0)
                {
                    _database.Update(userInstance);
                }
                else
                {
                    _database.Insert(userInstance);
                }
            }
        }

        public int DeleteUser(User userInstance)
        {
            var id = userInstance.Id;
            if (id != 0)
            {
                lock (_collisionLock)
                {
                    _database.Delete<User>(id);
                }
            }
            this.Users.Remove(userInstance);
            return id;
        }

        public User GetUserById(int id)
        {
            lock (_collisionLock)
            {
                return _database.Table<User>().FirstOrDefault(user => user.Id == id);
            }
        }
    }
}
