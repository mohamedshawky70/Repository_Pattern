using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Models;

namespace Repository_Pattern.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Auther> autherss  { get; set; }
        public DbSet<Book> bookss { get; set; }
    }
}
