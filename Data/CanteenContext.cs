using Microsoft.EntityFrameworkCore;
using Jopp_lunch.Model;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jopp_lunch.Data
{
    public class CanteenContext : IdentityDbContext<User>
    {
        public DbSet<Canteen>? vydejni_mista { get; set; }
        public DbSet<User>? uzivatele { get; set; }
        public DbSet<Soup>? polevky { get; set; }
        public DbSet<Lunch>? obedy { get; set; }
        public DbSet<Choice>? vybery { get; set; }
        

        public CanteenContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var editor = new IdentityRole("editor");
            editor.NormalizedName = "editor";

            var chef = new IdentityRole("chef");
            chef.NormalizedName = "chef";

            var employee = new IdentityRole("employee");
            employee.NormalizedName = "employee";
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            modelBuilder.Entity<User>()
            .HasIndex(u => u.osobni_cislo)
            .IsUnique();
            modelBuilder.Entity<IdentityRole>().HasData(admin, editor, chef, employee);
            modelBuilder.Entity<User>().ToTable("uzivatele");
            modelBuilder.Entity<Lunch>().ToTable("obedy");
            modelBuilder.Entity<Soup>().ToTable("polevky");
            modelBuilder.Entity<Choice>().ToTable("vybery");
            modelBuilder.Entity<Canteen>().ToTable("vyjedni_mista");
        }
    }
}
