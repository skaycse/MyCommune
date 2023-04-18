namespace MyCommune.Custom
{
    using Microsoft.EntityFrameworkCore;
    using MyCommune.DataModels.Users;

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid guid = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = guid,
                Email = "superadmin@commune.com",
                Password = "Commune@123",
                Mobile = "7827020076",
                CreatedDate = DateTime.Now,
                LastLoginDate = null,
                ModifiedDate =  DateTime.Now
            });
            modelBuilder.Entity<UserDetail>().HasData(new UserDetail
            {
                FirstName = "Test",
                LastName = "Test",
                Address = "Society",
                UserId = guid,
                Id = 1
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UsersD { get; set; }
    }
}
