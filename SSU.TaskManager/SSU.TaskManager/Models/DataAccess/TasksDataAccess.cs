using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SSU.TaskManager.Models.DataAccessInterface;
using SSU.TaskManager.Entities;

namespace SSU.TaskManager.Models
{
    public class TasksDataAccess : ITasksDataAccess
    {
        private SQLiteConnection _database;
        private static object _collisionLock = new object();
        public ObservableCollection<Task> Tasks { get; set; }

        public TasksDataAccess()
        {
            _database =
            DependencyService.Get<IDatabaseConnection>().
            DbConnection();
            _database.CreateTable<Task>();

            Tasks = new ObservableCollection<Task>(_database.Table<Task>());

        }

        public IEnumerable<Task> GetAll()
        {
            lock (_collisionLock)
            {
                return _database.
                  Query<Task>
                  ("SELECT * FROM Tasks").
                  AsEnumerable();
            }
        }

        public void SaveTask(Task taskInstance)
        {
            lock (_collisionLock)
            {
                if (taskInstance.Id != 0)
                {
                    _database.Update(taskInstance);
                }
                else
                {
                    _database.Insert(taskInstance);
                }
            }
        }

        public int DeleteTask(Task taskInstance)
        {
            var id = taskInstance.Id;
            if (id != 0)
            {
                lock (_collisionLock)
                {
                    _database.Delete<Task>(id);
                }
            }
            this.Tasks.Remove(taskInstance);
            return id;
        }

        public Task GetTaskById(int id)
        {
            lock (_collisionLock)
            {
                return _database.Table<Task>().FirstOrDefault(task => task.Id == id);
            }
        }

    }
}
