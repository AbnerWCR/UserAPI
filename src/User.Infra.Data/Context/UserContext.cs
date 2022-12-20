using Microsoft.EntityFrameworkCore;
using User.Infra.Data.Mapping;
using Entity = User.Domain.Entities;

namespace User.Infra.Data.Context
{
    public class UserContext : DbContext 
    {
        public UserContext()
        {

        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<Entity.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMap());
            //builder.Entity<Entity.User>(new UserMap().Configure);
        }
    }
}
