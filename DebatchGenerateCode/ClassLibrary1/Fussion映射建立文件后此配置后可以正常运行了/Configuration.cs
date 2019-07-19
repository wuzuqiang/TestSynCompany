using FusionFramework.EntityFramework;

namespace Fusion.Infrastructure.DBContext.SqlServer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SqlServerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Fusion.Infrastructure.DBContext.SqlServer.SqlServerDbContext context)
        {
            Init(context, "menu");
            Init(context, "param");
            //Init(context, "project-name");
        }
    }
}
