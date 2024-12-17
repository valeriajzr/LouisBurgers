using System.ComponentModel.DataAnnotations;

namespace LouisBurgers.Models
{
    public class orderBurger
    {
        public int idOrder { get; set; }
        public int idBurger { get; set; }
        public int? idExtra { get; set; }
        public Order Order { get; set; } = null!;
        public Burger Burger { get; set; } = null!;
    }
}
