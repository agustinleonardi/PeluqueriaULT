using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Turnos.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Reemplaza la cadena de conexión por la de tu entorno si es necesario
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PeluqueriaDemo;User Id=SA;Password=Quilmesagustin8;TrustServerCertificate=True");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
