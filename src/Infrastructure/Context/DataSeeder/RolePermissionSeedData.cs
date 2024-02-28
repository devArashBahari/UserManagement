using Context.DataBaseContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Context.DataSeeder
{
    public static class RolePermissionSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context =
                new UserManagementContext(
                    serviceProvider.GetRequiredService<DbContextOptions<UserManagementContext>>());
            CompareRolePermissions(context, 1, true, false);
            CompareRolePermissions(context, 2, false, false);
            CompareRolePermissions(context, 3, false, true);
            AddingBranchesUserPermissions(context);
        }

        private static void CompareRolePermissions(UserManagementContext context, int roleId, bool getAll, bool forClient)
        {
            var rolePermIds = context.RolePermissions.Where(a => a.RoleId == roleId).ToList();
            var permissionsQ = context.Permissions.AsQueryable();
            if (!getAll)
            {
                permissionsQ = permissionsQ.Where(p => p.ForClient == forClient);
            }
            var permissions = permissionsQ.ToList();
            if (permissions.Count <= rolePermIds.Count) return;
            context.RolePermissions.RemoveRange(rolePermIds);
            foreach (var perm in permissions)
            {
                context.RolePermissions.Add(new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = perm.Id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                });
            }
            context.SaveChanges();
        }

        public static void AddingBranchesUserPermissions(UserManagementContext context)
        {
            #region Contents

            if (!context.RolePermissions.Any(x => x.RoleId == 4))
            {
                var list = new List<RolePermission>
                {
                new()
                {
                    RoleId = 4,
                    PermissionId = 51,//Get Discounts
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 197,//Get Lotteries
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 153,//Get Airports from tourism
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 339,//Get Point trend/data
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 338, //Get Point trend/total
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 337, //Get trend/group/burn
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 336,//Get trend/group/earn
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new()
                {
                    RoleId = 4,
                    PermissionId = 131,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
                ,
                new()
                {
                    RoleId = 4,
                    PermissionId = 340,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            };

                context.RolePermissions.AddRange(list);
            }

            #endregion

            context.SaveChanges();
        }
    }
}