

using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data
{
    public class StreamerDBContext : DbContext
    {
        // Se convierte las clases de c# (streamer y video) cómo entidades
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; 
                Initial Catalog=Streamer;user id=sa;password=admin123"); //cadena de conexión
        }
        public DbSet<Streamer>? Streamers {get; set;}
        public DbSet <Video>? Videos { get; set;}
 
    }
}
