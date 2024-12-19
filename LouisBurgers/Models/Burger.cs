namespace LouisBurgers.Models
{
    public class Burger
    {
        public int idBurger { get; set; }
        public string name { get; set;}
        public int price { get; set; }
        public List<orderBurger> orderBurger { get; set;  } = new List<orderBurger>();
    }
}
