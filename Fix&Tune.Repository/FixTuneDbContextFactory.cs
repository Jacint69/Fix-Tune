using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Fix_Tune.Repository
{
    public class FixTuneDbContextFactory : IDesignTimeDbContextFactory<FixTuneDbContext>
    {
        public FixTuneDbContext CreateDbContext(string[] args)
        {
            // Konfigurációs beállítások betöltése
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_develop.json") // Beolvassa az appsettings.json fájlt
                .Build();

            var confbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_develop.json", optional: false, reloadOnChange: true);
            

            // DbContextOptionsBuilder létrehozása
            var optionsBuilder = new DbContextOptionsBuilder<FixTuneDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection"); // Kiolvassa a connection stringet
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion("8.0.30")); // Beállítja a MySQL adatbázis kapcsolatot

            return new FixTuneDbContext(optionsBuilder.Options); // Visszaadja a FixTuneDbContext példányát
        }
    }
}
