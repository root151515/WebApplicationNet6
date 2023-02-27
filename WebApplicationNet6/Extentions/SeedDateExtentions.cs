using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplicationNet6.Model;

namespace WebApplicationNet6.Extentions
{
    public static class SeedDateExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("5491A8F3-1E36-4AC8-A9F7-91F7F4431636"),
                UserName = "Test",
            });

            modelBuilder.Entity<Article>().HasData(new Article
            {
                Id = 1,
                Title = "TestTitle",
                Content = "TestContent",
                PostTime = DateTime.Now,
                UserId = new Guid("5491A8F3-1E36-4AC8-A9F7-91F7F4431636"),
            });
        }
    }
}
