using Common.Helper;
using Context.DataBaseContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Context.DataSeeder
{
    public static class UserSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new UserManagementContext(serviceProvider.GetRequiredService<DbContextOptions<UserManagementContext>>());
            if (context.Users.Any())
            {
                return;
            }
            var passwordHelper = new PasswordHelper();
            var app = new List<User>
            {
                new User
                {

                    FirstName = "Amir",
                    LastName ="Rezaei",
                    Phone = "09900071054",
                    ApplicationFk=1,
                    IsActive=true,
                    NationalCode = "0020718748",
                    Password=passwordHelper.EncodePasswordBcrypt("IZB!QAZ2wsx"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt=DateTime.Now,
                    IsDeleted = false
                }, new User
                {

                    FirstName = "Saba",
                    LastName ="Karim Zadeh",
                    Phone = "09036997292",
                    ApplicationFk=1,
                    NationalCode = "1362749826",
                    IsActive=true,
                    Password=passwordHelper.EncodePasswordBcrypt("IZB!QAZ2wsx"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt=DateTime.Now,
                    IsDeleted = false
                }, new User
                {
                    FirstName = "Behrouz",
                    LastName ="Torabi",
                    Phone = "09198040525",
                    NationalCode = "1288428960",
                    ApplicationFk=1,
                    IsActive=true,
                    Password=passwordHelper.EncodePasswordBcrypt("IZB!QAZ2wsx"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt=DateTime.Now,
                    IsDeleted = false
                }, new User
                {

                    FirstName = "Arash",
                    LastName ="Bahari",
                    Phone = "09124418017",
                    NationalCode = "4270278110",
                    ApplicationFk=1,
                    IsActive=true,
                    Password=passwordHelper.EncodePasswordBcrypt("arash12345#"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt=DateTime.Now,
                    IsDeleted = false
                },
            };

            context.Users.AddRange(app);

            context.SaveChanges();
        }
    }
}
