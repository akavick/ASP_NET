using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SortPaginateFilter.Models;





namespace SortPaginateFilter.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            CheckDatabase();
        }

        private void CheckDatabase()
        {
            Database.EnsureCreated();
        }
    }
}
