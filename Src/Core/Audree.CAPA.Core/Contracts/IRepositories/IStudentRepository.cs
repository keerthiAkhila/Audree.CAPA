using Audree.CAPA.Core.Models.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audree.CAPA.Core.Contracts.IRepositories
{
   public interface IStudentRepository
    {
        Task<string> CreateOrUpdate(Student student);
        Task<List<Student>> GetAllStudentdetails();
    }
}
