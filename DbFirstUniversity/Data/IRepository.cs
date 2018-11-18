using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using DbFirstUniversity.Models;

namespace DbFirstUniversity.Data
{

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }

    public interface IRepository<T> where T : class 
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Remove(T entity);
    }

    public class Repository<T> : IRepository<T> where T :class
    {

        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
             _context.Set<T>().Remove(entity);
        }
    }



}
