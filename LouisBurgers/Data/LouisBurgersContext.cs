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

            modelBuilder.Entity<Burger>()
               .HasMany(b => b.orderBurger)
               .WithMany(b => b.Order)
               .UsingEntity(
                   "orderBurger",
                   l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("idBurger").HasPrincipalKey(nameof(Burger.idBurger)),
                   r => r.HasOne(typeof(Post)).WithMany().HasForeignKey("idOrder").HasPrincipalKey(nameof(Order.idOrder)),
                   j => j.HasKey("idBurger", "idOrder"));
        

        //nuevo
        modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey("idOrder");
                entity.Property("idOrder").ValueGeneratedOnAdd();
                entity.HasMany("orderBurger");
            });


            //nuevo - Configurar orderBurger como tabla intermedia
            modelBuilder.Entity<orderBurger>().HasKey(ob => new {ob.idOrder, ob.idBurger}); //clave compuesta
        }
    }
}
