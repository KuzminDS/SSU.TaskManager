using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.Models.DaoInterface;
using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using SSU.TaskManager.Models.DataAccessInterface;

namespace SSU.TaskManager.BusinessLogic.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardsDataAccess _boardRepository;

        public BoardService(IBoardsDataAccess boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public IEnumerable<Board> GetAll()
        {
            return _boardRepository.GetAll();         
        }

        public IEnumerable<Board> GetByCondition(Func<Board, bool> where)
        {
            return GetAll().Where(where);
        }

        public Board GetById(int id)
        {
            return _boardRepository.GetBoardById(id);
        }
    }
}