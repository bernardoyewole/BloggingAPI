using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public interface IBlogManagementContext : IDbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }

    public class BlogManagementContext : DbContext, IBlogManagementContext
    {
        public BlogManagementContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=BlogManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
