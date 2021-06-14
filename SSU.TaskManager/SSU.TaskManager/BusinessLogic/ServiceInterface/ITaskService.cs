using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;

namespace SSU.TaskManager.BusinessLogic.ServiceInterface
{
    public interface ITaskService
    {
        void Add(Task entity);
        void Update(Task entity);
        void Delete(Task entity);
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        IEnumerable<Task> GetByCondition(Func<Task, bool> where);
    }
}
