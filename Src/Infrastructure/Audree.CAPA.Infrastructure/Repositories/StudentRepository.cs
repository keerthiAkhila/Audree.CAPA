using Audree.CAPA.Core.Contracts.IRepositories;
using Audree.CAPA.Core.Contracts.IUnitOfWork;
using Audree.CAPA.Core.Models.Masters;
using Audree.CAPA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.CAPA.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly CAPAContext _baseContext;
         
        #region DependencyInjection
        public StudentRepository(IUnitOfWork UnitOfWork, CAPAContext baseContext)
        {
            _UnitOfWork = UnitOfWork;
            _baseContext = baseContext;
        }
        #endregion
        #region AddorUpdate
        /// <summary>
        /// Purpose     :  Add or Update Sample
        /// Created By  :  Audree Infotech Pvt. Ltd.
        /// Created On    :  31-08-21
        /// </summary>
        /// <param name="Student"></param>
        /// <returns></returns>
        public async Task<string> CreateOrUpdate(Student Student)
        {
            string Message = "";
            using (var transaction = _baseContext.Database.BeginTransaction())
            {
                try
                {
                    if (Student.Id == 0)
                    {
                        _baseContext.Students.Add(Student);
                        _baseContext.SaveChanges();
                    }
                    else
                    {
                        Student g1 = await _baseContext.Students.AsNoTracking().Where(w => w.Id == Student.Id).FirstOrDefaultAsync();
                        g1.Name = Student.Name;
                        _baseContext.Students.Update(g1);
                    }
                    _baseContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception Ex)
                {
                    Message = "Error,In Posting";
                    transaction.Rollback();
                }
            }
            return Message;
        }
        #endregion
        #region GetStudent
        /// <summary>
        /// Purpose     :   To Get Sample List
        /// Created By  :   Audree Infotech Pvt. Ltd.
        /// Created On    :  31-08-21
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<List<Student>> GetAllStudentdetails()
        {
            try
            {
                using (_UnitOfWork)
                {
                    var student = await _baseContext.Students.ToListAsync();
                    return student;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
