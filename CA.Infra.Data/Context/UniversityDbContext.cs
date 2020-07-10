using CA.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CA.Infra.Data.Context
{
    public class UniversityDbContext : DbContext
    {
        public  UniversityDbContext(DbContextOptions<UniversityDbContext> options): base(options)
        {
            
        }

        public DbSet<Course> Cources;
    }
}