using System;

using Microsoft.EntityFrameworkCore;

using Permissions.DAL.Repository.Enums;
using Permissions.DAL.Repository.Models;



namespace Permissions.DAL.Repository
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
              : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> RolePermissions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserPermission>()
                .HasKey(rp => new { rp.UserId, rp.PermissionId });

            modelBuilder.Entity<UserPermission>()
                .HasOne(rp => rp.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(rp => rp.UserId);

            modelBuilder.Entity<UserPermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(c => c.UserPermissions)
                .HasForeignKey(rp => rp.PermissionId);

            AddTestData(modelBuilder);

        }

        private void AddTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new { Id = 1, Login = @"MINSK\akavick" },
                new { Id = 2, Login = @"MINSK\maul" },
                new { Id = 3, Login = @"MINSK\arba" });

            modelBuilder.Entity<Status>().HasData(
                new { Id = 1, Title = RequestStatus.New.ToString() },
                new { Id = 2, Title = RequestStatus.Approved.ToString() },
                new { Id = 3, Title = RequestStatus.Rejected.ToString() });




            modelBuilder.Entity<Request>().HasData(
                new { Id = 1, AuthorId = 1, StatusId = (int)RequestStatus.New },
                new { Id = 2, AuthorId = 2, StatusId = (int)RequestStatus.Approved },
                new { Id = 3, AuthorId = 1, StatusId = (int)RequestStatus.Approved },
                new { Id = 4, AuthorId = 1, StatusId = (int)RequestStatus.Rejected },
                new { Id = 5, AuthorId = 3, StatusId = (int)RequestStatus.New });



            foreach (var permType in Enum.GetValues(typeof(PermissionType)))
            {
                modelBuilder.Entity<Permission>().HasData(
                    new { Id = (int)permType, Title = permType.ToString() });


            }

            modelBuilder.Entity<UserPermission>().HasData(
                new { UserId = 1, PermissionId = 1, ObjectId = Guid.NewGuid() },
                new { UserId = 1, PermissionId = 2, ObjectId = Guid.NewGuid() },
                new { UserId = 1, PermissionId = 5, ObjectId = Guid.NewGuid() },
                new { UserId = 1, PermissionId = 6, ObjectId = Guid.NewGuid() },
                new { UserId = 1, PermissionId = 8, ObjectId = Guid.NewGuid() },
                new { UserId = 1, PermissionId = 9, ObjectId = Guid.NewGuid() },
                new { UserId = 1, PermissionId = 11, ObjectId = Guid.NewGuid() });


        }

    }
}
