namespace CameraBazza.Data
{
   using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class CamerBazzaDbContext : IdentityDbContext<User>
    {
        public CamerBazzaDbContext(DbContextOptions<CamerBazzaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
