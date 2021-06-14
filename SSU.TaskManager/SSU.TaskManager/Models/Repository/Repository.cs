//using Microsoft.EntityFrameworkCore;
//using SSU.TaskManager.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;


//namespace SSU.TaskManager.Models.Repository
//{
//    public class Repository<T> : IRepository<T>
//    {
//        protected readonly DbContext _dbContext;

//        public Repository(DbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public void Add(T entity)
//        {
//            _dbContext.Set<T>().Add(entity);
//            _dbContext.SaveChanges();
//        }

//        public void Delete(T entity)
//        {
//            _dbContext.Set<T>().Remove(entity);
//            _dbContext.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> GetAll()
//        {
//            return _dbContext.Set<T>();
//        }

//        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> where)
//        {
//            return _dbContext.Set<T>().Where(where);
//        }

//        public T GetById(int id)
//        {
//            return _dbContext.Set<T>().Find(id);
//        }


//        public void Update(T entity)
//        {
//            _dbContext.Set<T>().Update(entity);
//            _dbContext.SaveChanges();
//        }
//    }
//}
