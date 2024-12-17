namespace LouisBurgers.Models
{
    public class Burgers
    {
        public int idBurger {  get; set; }
        public string BurgerName { get; set; }
        public string  Meat { get; set;}
        public string Vegetables { get; set;}
        public string? Extras { get; set; }

        //esto es nuevo
        public ICollection<orderBurger> orderBurger { get; set; }

    }
}
