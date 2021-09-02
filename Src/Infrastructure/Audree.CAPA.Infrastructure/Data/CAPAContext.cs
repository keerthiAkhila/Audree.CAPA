using Audree.CAPA.Core.Models.Masters;
using Microsoft.EntityFrameworkCore;

namespace Audree.CAPA.Infrastructure.Data
{
    public  class CAPAContext : DbContext
    {
        #region DB Context
        public CAPAContext(DbContextOptions<CAPAContext> options) : base(options) { }
        #endregion
        public DbSet<Student> Students { get; set; }
    }
}