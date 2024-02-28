using Domain.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Context.DataBaseContext
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext()
        {
        }

        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Application> Applications { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Scope> Scopes { get; set; } = null!;
        public DbSet<UserLoginHistory> UserLoginHistories { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public DbSet<HubLog> HubLogs { get; set; } = null!;
        public DbSet<Client> clients { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(e =>
            //{
            //    e.HasIndex(u => new { u.ApplicationFk, u.Phone }).IsUnique();
            //    e.HasOne(u => u.Application).WithMany(app => app.Users).HasForeignKey(u => u.ApplicationFk);
            //    e.HasMany(u => u.Roles).WithMany(r => r.Users);
            //});

            //modelBuilder.Entity<Role>(e =>
            //{
            //    e.HasIndex(r => r.Id);
            //    e.HasMany(r => r.Permissions).WithMany(p => p.Roles);
            //});

            modelBuilder.Entity<Domain.Entities.Application>(e =>
            {
                e.HasMany(a => a.Scopes).WithMany(s => s.Applications)
                    .UsingEntity(j => j.ToTable("ApplicationScopes"));
            });


            modelBuilder.Entity<Scope>(e =>
            {
                e.HasIndex(s => s.Name).IsUnique();
                e.HasIndex(s => s.CreatedAt);
                e.HasIndex(s => s.IsDeleted);
            });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Base && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (Base)entityEntry.Entity;
                entity.UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Base && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (Base)entityEntry.Entity;
                entity.UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}