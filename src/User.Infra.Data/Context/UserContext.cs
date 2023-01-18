using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;
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
        public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ErrorMap());

            base.OnModelCreating(builder);
        }
    }
}
