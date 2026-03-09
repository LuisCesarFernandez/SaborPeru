using Microsoft.EntityFrameworkCore;
using saborperu.Entities;

namespace saborperu.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options):base(options) { }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plato>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Plato>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId)
                .IsRequired();
            
            modelBuilder.Entity<Plato>()
                .Property(p => p.CategoriaId)
                .ValueGeneratedNever();
            
            modelBuilder.Entity<Pedido>()
                .Property(p=>p.Total)
                .HasPrecision(10, 2);
            
            modelBuilder.Entity<DetallePedido>()
                .Property(p=>p.PrecioUnitario)
                .HasPrecision(10, 2);
        }
    }
}
