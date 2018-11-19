using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirstUniversity.Models;
using DbFirstUniversity.Repositories;
using Maple.Core.Repositories;

namespace DbFirstUniversity.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Student { get; }
        int Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public readonly UniversityContext _context;

        public IStudentRepository Students { get; set; }

        public UnitOfWork(UniversityContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
        }

        public IStudentRepository Student => throw new NotImplementedException();

        public int Save()
        {
           return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }

         
    }
}
