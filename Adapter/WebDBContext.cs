using CreArtHub.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Adapter
{
    public class WebDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<BoughtProduct> BoughtProducts { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
		public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public WebDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string adminRoleName = "admin";
			string userRoleName = "user";
			string moderatorRoleName = "moderator";

			string adminEmail = "admin@mail.ru";
			string adminPassword = "321";

			string userEmail = "1@1.com";
			string userPassword = "123";

			Role adminRole = new Role { Id = 1, Name = adminRoleName };
			Role userRole = new Role { Id = 2, Name = userRoleName };
			Role moderatorRole = new Role { Id = 3, Name = moderatorRoleName };
			User Anonymous = new User { Id = 1, Name = "anon", Email = "anon@mail.com", Password = "anon", RoleId = 2 };
			User adminUser = new User { Id = 2, Name = "admin", Email = adminEmail, Password = adminPassword, RoleId = 1 };
			User User = new User { Id = 3, Name = "user", Email = userEmail, Password = userPassword, RoleId = 2 };
			User Moderator = new User { Id = 4, Name = "moder", Email = "moder@mail.com", Password = "1", RoleId = 3 };

			Category[] Categories = new Category[] {
				new Category(){ Id = 1, Name = "Без категории" },
                new Category(){ Id = 2, Name = "Рисунки" },
                new Category(){ Id = 3, Name = "Фотографии" },
                new Category(){ Id = 4, Name = "Тревл-блог" },
                new Category(){ Id = 5, Name = "Программы" },
                new Category(){ Id = 6, Name = "Музыка" },
                new Category(){ Id = 7, Name = "Истории" },
                new Category(){ Id = 8, Name = "Книги" },
                new Category(){ Id = 9, Name = "Видео" },
                new Category(){ Id = 10, Name = "Другое" },
            };  

			modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, moderatorRole });
			modelBuilder.Entity<User>().HasData(new User[] { Anonymous, adminUser, User, Moderator });
            modelBuilder.Entity<Category>().HasData(Categories);

            base.OnModelCreating(modelBuilder);
		}
	}
}
