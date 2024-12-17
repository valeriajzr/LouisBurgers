using System.Text.Json.Serialization;

namespace LouisBurgers.Models
{
    //todo este modelo es nuevo
    public class Order
    {
        public int idOrder { get; set; }
        public decimal totalPrice { get; set; }

        //Aqui se declara que una orden puede tener una o muchas orderBurger
        [JsonIgnore]
        public List<orderBurger> orderBurger { get; set; } = new List<orderBurger>();
    }
}
