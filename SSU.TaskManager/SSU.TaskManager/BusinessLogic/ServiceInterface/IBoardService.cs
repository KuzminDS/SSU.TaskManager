using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SSU.TaskManager.BusinessLogic.ServiceInterface
{
    public interface IBoardService
    {
        IEnumerable<Board> GetAll();
        Board GetById(int id);
        IEnumerable<Board> GetByCondition(Func<Board, bool> where);
    }
}