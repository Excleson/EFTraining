using Microsoft.EntityFrameworkCore;

namespace efcore.Entity
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("user_pkey");
                entity.HasMany<Address>(e=>e.Addresses)
                .WithOne(e => e.User).HasConstraintName("t__Adress_fkey").IsRequired();
            });

        }
    }

}
