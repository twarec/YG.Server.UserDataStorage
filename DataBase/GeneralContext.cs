using Microsoft.EntityFrameworkCore;
using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.DataBase
{
    public class GeneralContext : DbContext
    {
        public DbSet<Root> Roots { get; set; }
        public DbSet<Field> Fields { get; set; }

        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
