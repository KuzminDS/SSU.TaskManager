using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.Common.Ioc;
using SSU.TaskManager.Entities;
using SSU.TaskManager.Models.Dao;
using System;
using System.IO;
using System.Linq;

namespace UiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = DependenciesResolver.Kernel.GetService<IUserService>();
            //var user = new User
            //{
            //    FirstName = "Ivan",
            //    LastName = "Ivanov",
            //    Login = "11",
            //    Password = "22"
            //};
            //userService.Add(user);

            //foreach (var item in userService.GetAll())
            //{
            //    Console.WriteLine($"{item.Id} {item.LastName} {item.FirstName} {item.Login} {item.Password}");
            //}

            //Console.WriteLine();
            //userService.Delete(2);

            //foreach (var item in userService.GetAll())
            //{
            //    Console.WriteLine($"{item.Id} {item.LastName} {item.FirstName} {item.Login} {item.Password}");
            //}

            //Console.WriteLine();
            //user.Id = 1;
            //user.LastName = "Petrov";
            //userService.Update(user);

            var boardService = DependenciesResolver.Kernel.GetService<IBoardService>();

            //foreach (var item in boardService.GetAll())
            //{
            //    Console.WriteLine($"{item.Id} {item.Title}");
            //}

            var taskService = DependenciesResolver.Kernel.GetService<ITaskService>();

            var task = new Task
            {
                Title = "Покодить",
                BoardId = 1,
                UserId = 1
            };

            //taskService.Add(task);

            Console.WriteLine(userService.GetById(1));
            Console.WriteLine(boardService.GetById(1));

            foreach (var item in taskService.GetAll())
            {
                Console.WriteLine($"{item.Id} {item.Title} {item.Board.Title} {item.User.LastName}");
            }

            task.Id = 1;
            task.Description = "Pokodit";
            task.DeadLine = "1-02-2020";
            task.BoardId = 2;

            taskService.Update(task);

            foreach (var item in taskService.GetAll())
            {
                Console.WriteLine($"{item.Id} {item.Title} {item.Description} {item.DeadLine} {item.Board.Title} {item.User.LastName}");
            }
        }
    }
}
