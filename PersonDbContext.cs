using Migration.Data.Entity.Models;
using System.Data.Entity;

namespace Migration.Data.Entity
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext( string connectionString )
            : base( connectionString )
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
        }
    }
}
