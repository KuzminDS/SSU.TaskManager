using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;

namespace SSU.TaskManager.BusinessLogic.ServiceInterface
{
    public interface IUserService
    {
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
        IEnumerable<User> GetAll();
        User GetById(int id);
        IEnumerable<User> GetByCondition(Func<User, bool> where);
    }
}
