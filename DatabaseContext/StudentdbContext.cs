using Microsoft.EntityFrameworkCore;
using StudentReg.Models.DBEntities;

namespace StudentReg.DatabaseContext
{
    public class StudentdbContext : DbContext
    {
        public StudentdbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
    }
}
