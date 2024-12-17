namespace LouisBurgers.Models
{
    //todo este modelo es nuevo
    public class Order
    {
        public int idOrder { get; set; }
        public decimal totalPrice { get; set; }

        //Aqui se declara que una orden puede tener una o muchas orderBurger
        public ICollection<orderBurger> orderBurger { get; } = new List<orderBurger>();
    }
}
