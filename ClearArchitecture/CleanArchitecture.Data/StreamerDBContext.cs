

using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        // Se convierte las clases de c# (streamer y video) cómo entidades
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; 
                Initial Catalog=Streamer;user id=sa;password=admin123")
               .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
               .EnableSensitiveDataLogging();

            ; //cadena de conexión
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
               .HasMany(p => p.Actores)
               .WithMany(t => t.Videos)
               .UsingEntity<VideoActor>(
                   pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
               );



        }

        public DbSet<Streamer>? Streamers {get; set;}
        public DbSet <Video>? Videos { get; set;}
 
    }
}
