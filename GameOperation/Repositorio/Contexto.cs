using Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repositorio
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("GameOperationDB")
        {

        }

        public DbSet<Player> Player { get; set; }

        public DbSet<Game> Game { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
