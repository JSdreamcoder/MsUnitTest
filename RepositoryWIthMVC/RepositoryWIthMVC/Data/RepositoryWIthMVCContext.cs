#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryWIthMVC.Models;

namespace RepositoryWIthMVC.Data
{
    public class RepositoryWIthMVCContext : DbContext
    {
        public RepositoryWIthMVCContext (DbContextOptions<RepositoryWIthMVCContext> options)
            : base(options)
        {
        }

        public DbSet<RepositoryWIthMVC.Models.Account> Account { get; set; }

        public DbSet<RepositoryWIthMVC.Models.Customer> Customer { get; set; }
    }
}
