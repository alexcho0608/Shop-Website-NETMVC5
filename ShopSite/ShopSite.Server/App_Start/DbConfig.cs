namespace ShopSite.Server.App_Start
{
    using System.Data.Entity;
    using Data.Data;
    using Data.Migrations;
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDbContext, Configuration>());
            ShopDbContext.Create().Database.Initialize(true);
        }
    }
}