using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.Models.DaoInterface;
using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using SSU.TaskManager.Models.DataAccessInterface;

namespace SSU.TaskManager.BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITasksDataAccess _taskRepository;

        public TaskService(ITasksDataAccess taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Add(Task entity)
        {
            _taskRepository.SaveTask(entity);
        }

        public void Delete(Task entity)
        {
            _taskRepository.DeleteTask(entity);
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public IEnumerable<Task> GetByCondition(Func<Task, bool> where)
        {
            return GetAll().Where(where);
        }

        public Task GetById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public void Update(Task entity)
        {
            _taskRepository.SaveTask(entity);
        }
    }
}