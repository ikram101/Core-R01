using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DbFirstUniversity.Data
{
    public interface IRepository where TEntity : class
    {
        IEnumerable GetAll();
        IEnumerable Find(Expression> predicate);
        TEntity Get(object Id);
        void Add(TEntity entity);
        void AddRange(IEnumerable entities);
        void Update(TEntity entity);
        void Remove(object Id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable entities);
    }
   

}
