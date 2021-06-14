
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
    public class UserService : IUserService
    {
        private readonly IUsersDataAccess _userService;

        public UserService(IUsersDataAccess userService)
        {
            _userService = userService;
        }

        public void Add(User entity)
        {
            _userService.SaveUser(entity);
        }

        public void Delete(User entity)
        {
            _userService.DeleteUser(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public IEnumerable<User> GetByCondition(Func<User, bool> where)
        {
            return GetAll().Where(where);
        }

        public User GetById(int id)
        {
            return _userService.GetUserById(id);
        }

        public void Update(User entity)
        {
            _userService.SaveUser(entity);
        }
    }
}