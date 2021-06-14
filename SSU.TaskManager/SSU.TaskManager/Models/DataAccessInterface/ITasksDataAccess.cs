using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.Models.DataAccessInterface
{
    public interface ITasksDataAccess
    {
        IEnumerable<Task> GetAll();
        void SaveTask(Task taskInstance);
        int DeleteTask(Task taskInstance);
        Task GetTaskById(int id);
    }
}
