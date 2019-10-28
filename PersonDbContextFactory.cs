using Microsoft.Extensions.Configuration;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace Migration.Data.Entity
{
    public class PersonDbContextFactory: IDbContextFactory<PersonDbContext>
    {
        public PersonDbContext Create()
        {
            // Doesn't work.
            var connectionString = GetConnectionStringFromSettings();

            // Does work.
            //var connectionString = GetConnectionString();

            return new PersonDbContext( connectionString );
        }

        private string GetConnectionString()
        {
            return "Server=localhost;Database=Migrations.Test;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        private string GetConnectionStringFromSettings()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath( Directory.GetCurrentDirectory() )
               .AddJsonFile( "appsettings.json", optional: false );

            var configuration = builder.Build();

            return configuration.GetConnectionString( "DefaultConnection" );
        }
    }
}
