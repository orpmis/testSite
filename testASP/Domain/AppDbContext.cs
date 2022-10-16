using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testASP.Domain.Entities;

namespace testASP.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext() :base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GoodsItem> GoodItems { get; set; }
        public DbSet<GoodsImages> GoodsImages { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionInCat> OptionsInCats { get; set; }
        public DbSet<OptionInGood> OptionsInGoods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = "1c3d07c1-379d-4402-9313-4b01e0761fc0",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = "97088e8a-3573-479a-99a3-2541e3e7c7de",
                UserName = "Admin1",
                NormalizedUserName = "ADMIN1",
                Email = "sm@mail.ru",
                NormalizedEmail = "SM@MAIL.RU",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "adminpass"),
                SecurityStamp = String.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                UserId = "97088e8a-3573-479a-99a3-2541e3e7c7de",
                RoleId = "1c3d07c1-379d-4402-9313-4b01e0761fc0"
            });

            builder.Entity<TextField>().HasData(new TextField()
            {
                Id = 1,
                CodeWord = "PageIndex",
                Name = "Главная"
            });

            builder.Entity<TextField>().HasData(new TextField()
            {
                Id = 2,
                CodeWord = "PageGoods",
                Name = "Товары"
            });

            builder.Entity<TextField>().HasData(new TextField()
            {
                Id = 3,
                CodeWord = "PageContacts",
                Name = "Контакты"
            });
        }
    }
}
