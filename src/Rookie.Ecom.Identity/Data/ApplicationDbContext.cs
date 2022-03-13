using Microsoft.EntityFrameworkCore;

namespace Rookie.Ecom.Identity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //code first
            //db first
            //model first
        }

    }
}
