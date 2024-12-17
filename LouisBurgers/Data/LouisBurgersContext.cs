using Azure;
using LouisBurgers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LouisBurgers.Data
{
    public class LouisBurgersContext : DbContext
    {
        public LouisBurgersContext(DbContextOptions<LouisBurgersContext> options)
            : base(options)
        {
        }

        public DbSet<Burgers> Burgers { get; set; }
        public DbSet<Extras> Extras { get; set; }
        public DbSet<orderBurger> orderBurger { get; set; }
        public DbSet<Burger> Burger { get; set; }

        //nuevo
        public DbSet<Order> order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Indica que no hay una tabla para la clase BurgerDetails usando .HasNoKey()
            modelBuilder.Entity<Burgers>().HasNoKey();
            modelBuilder.Entity<Extras>().HasKey("idExtra");
            modelBuilder.Entity<Burger>().HasKey("idBurger");
            modelBuilder.Entity<Order>().HasKey("idOrder");

            // Configuración de la relación muchos a muchos usando orderBurger
            modelBuilder.Entity<orderBurger>()
                .HasKey(ob => new { ob.idOrder, ob.idBurger }); // Clave compuesta

            modelBuilder.Entity<orderBurger>()
                .HasOne(ob => ob.order)
                .WithMany(o => o.orderBurger)
                .HasForeignKey(ob => ob.idOrder);

            modelBuilder.Entity<orderBurger>()
                .HasOne(ob => ob.burger)
                .WithMany(b => b.orderBurger)
                .HasForeignKey(ob => ob.idBurger);
        }
    }
}
