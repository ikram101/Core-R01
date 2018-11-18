using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbFirstUniversity.Models;
namespace DbFirstUniversity.Data
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetTopTenStudents();
        Student GetClassToper();
    }

    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public UniversityContext UniversityContext
        {
            get { return _context as UniversityContext; }
        }

        public StudentRepository(UniversityContext context) : base(context)
        {

        }

        public Student GetClassToper()
        {
            return UniversityContext.Student.OrderByDescending(c=>c.Id).Single();
        }

        public IEnumerable<Student> GetTopTenStudents()
        {
            throw new NotImplementedException();
        }
    }
}
