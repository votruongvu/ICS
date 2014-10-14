using ICS.Core.Data;
using ICS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Domain.Data
{
    public class ICSDbContext : DbContext, IDbContext
    {
       private DbContextTransaction _transaction;

       public ICSDbContext()
            : base("ICS")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void BeginTransaction(IsolationLevel level)
        {
            _transaction = Database.BeginTransaction(level);
        }
    }
}
