using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.BusinessLogic.Services;
using SSU.TaskManager.Models;
using SSU.TaskManager.Models.Dao;
using SSU.TaskManager.Models.DaoImplementation;
using SSU.TaskManager.Models.DaoInterface;
using SSU.TaskManager.Models.DataAccessInterface;
using SSU.TaskManager.Models.Repository;
using System;

namespace SSU.TaskManager.Common.Ioc
{
    public static class DependenciesResolver
    {
        public static IServiceProvider Kernel { get; private set; }
        private static IServiceCollection _services { get; set; }

        static DependenciesResolver()
        {
            _services = new ServiceCollection();
            Kernel = Configurates();
        }

        private static IServiceProvider Configurates()
        {
            //_services.AddDbContext<TaskManagerContext>();
            //_services.AddTransient<DbContext, TaskManagerContext>();

            _services.AddTransient<ITasksDataAccess, TasksDataAccess>();
            _services.AddTransient<IBoardsDataAccess, BoardsDataAccess>();
            _services.AddTransient<IUsersDataAccess, UsersDataAccess>();

            _services.AddTransient<ITaskService, TaskService>();
            _services.AddTransient<IBoardService, BoardService>();
            _services.AddTransient<IUserService, UserService>();


            return _services.BuildServiceProvider();
        }
    }
}