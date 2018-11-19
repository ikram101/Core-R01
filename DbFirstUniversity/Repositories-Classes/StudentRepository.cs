using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbFirstUniversity.Models;
using DbFirstUniversity.Repositories;
using Maple.Core.Repositories;

namespace DbFirstUniversity.Repositories
{
     
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository(UniversityContext context) : base(context)
        {

        }

        public Student GetClassToper()
        {
            return UniversityContext.Student.OrderByDescending(c=>c.Id).Single();
        }

        public UniversityContext UniversityContext
        {
            get { return Context as UniversityContext; }
        }

    }
}
