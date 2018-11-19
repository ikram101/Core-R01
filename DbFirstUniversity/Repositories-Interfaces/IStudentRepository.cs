using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirstUniversity.Models;
using Maple.Core.Repositories;
using Maple.Core.Repositories;

namespace Maple.Core.Repositories
{
    public interface IStudentRepository: IRepository<Student>
    {
        Student GetClassToper();
    }
}
