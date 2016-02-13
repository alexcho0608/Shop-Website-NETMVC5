namespace ShopSite.Data.Data
{
    using ShopSite.Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IShopDbContext
    {
        IDbSet<Commit> Commits { get; set; }

        IDbSet<SoftwareProject> SoftwareProjects { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
